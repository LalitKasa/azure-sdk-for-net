﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Avro.Util;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.ChangeFeed.Models;

namespace Azure.Storage.ChangeFeed
{
    internal class ChangeFeed
    {
        /// <summary>
        /// BlobContainerClient for making List Blob requests and creating Segments.
        /// </summary>
        private readonly BlobContainerClient _containerClient;

        /// <summary>
        /// Queue of paths to years we haven't processed yet.
        /// </summary>
        private Queue<string> _years;

        /// <summary>
        /// Paths to segments in the current year we haven't processed yet.
        /// </summary>
        private Queue<string> _segments;

        /// <summary>
        /// The Segment we are currently processing.
        /// </summary>
        private Segment _currentSegment;

        /// <summary>
        /// The latest time the Change Feed can safely be read from.
        /// </summary>
        //TODO this can advance while we are iterating through the Change Feed.  Figure out how to support this.
        private DateTimeOffset _lastConsumable;

        /// <summary>
        /// User-specified start time.  If the start time occurs before Change Feed was enabled
        /// for this account, we will start at the beginning of the Change Feed.
        /// </summary>
        private DateTimeOffset? _startTime;

        /// <summary>
        /// User-specified end time.  If the end time occurs after _lastConsumable, we will
        /// end at _lastConsumable.
        /// </summary>
        private DateTimeOffset? _endTime;
        //private string _segmentsPathsContinutationToken;

        /// <summary>
        /// If this ChangeFeed has been initalized.
        /// </summary>
        private bool _isInitalized;

        // Start time will be rounded down to the nearest hour.
        public ChangeFeed(
            BlobServiceClient blobServiceClient,
            DateTimeOffset? startTime = default,
            DateTimeOffset? endTime = default)
        {
            _containerClient = blobServiceClient.GetBlobContainerClient(Constants.ChangeFeed.ChangeFeedContainerName);
            _years = new Queue<string>();
            _segments = new Queue<string>();
            _isInitalized = false;
            _startTime = RoundHourDown(startTime);
            _endTime = RoundHourUp(endTime);
        }

        /// <summary>
        /// Internal constructor for unit tests.
        /// </summary>
        /// <param name="containerClient"></param>
        internal ChangeFeed(
            BlobContainerClient containerClient)
        {
            _containerClient = containerClient;
        }

        private async Task Initalize(bool async)
        {
            // Check if Change Feed has been abled for this account.
            bool changeFeedContainerExists;

            if (async)
            {
                changeFeedContainerExists = await _containerClient.ExistsAsync().ConfigureAwait(false);
            }
            else
            {
                changeFeedContainerExists = _containerClient.Exists();
            }

            if (!changeFeedContainerExists)
            {
                //TODO improve this error message
                throw new ArgumentException("Change Feed hasn't been enabled on this account, or is current being enabled.");
            }

            // Get last consumable
            BlobClient blobClient = _containerClient.GetBlobClient(Constants.ChangeFeed.MetaSegmentsPath);
            BlobDownloadInfo blobDownloadInfo;
            if (async)
            {
                blobDownloadInfo = await blobClient.DownloadAsync().ConfigureAwait(false);
            }
            else
            {
                blobDownloadInfo = blobClient.Download();
            }

            JsonDocument jsonMetaSegment;
            if (async)
            {
                jsonMetaSegment = await JsonDocument.ParseAsync(blobDownloadInfo.Content).ConfigureAwait(false);
            }
            else
            {
                jsonMetaSegment = JsonDocument.Parse(blobDownloadInfo.Content);
            }

            //TODO what happens when _lastConsumable advances an hour?
            _lastConsumable = jsonMetaSegment.RootElement.GetProperty("lastConsumable").GetDateTimeOffset();

            // Get year paths
            if (async)
            {
                _years = await GetYearPaths(async: true).ConfigureAwait(false);
            }
            else
            {
                _years = GetYearPaths(async: false).EnsureCompleted();
            }

            // Dequeue any years that occur before start time
            if (_startTime.HasValue)
            {
                while (_years.Count > 0
                    && _years.Peek().ToDateTimeOffset() < _startTime)
                {
                    _years.Dequeue();
                }
            }

            if (_years.Count == 0)
            {
                return;
            }

            string firstYearPath = _years.Dequeue();

            // Get Segments for first year
            if (async)
            {
                _segments = await GetSegmentsInYear(
                    async: true,
                    yearPath: firstYearPath,
                    startTime: _startTime,
                    endTime: MinDateTime(_lastConsumable, _endTime))
                    .ConfigureAwait(false);
            }
            else
            {
                _segments = GetSegmentsInYear(
                    async: false,
                    yearPath: firstYearPath,
                    startTime: _startTime,
                    endTime: MinDateTime(_lastConsumable, _endTime))
                    .EnsureCompleted();
            }

            _currentSegment = new Segment(_containerClient, _segments.Dequeue());
            _isInitalized = true;
        }

        //TODO current round robin strategy doesn't work for live streaming!
        // The last segment may still be adding chunks.
        public async Task<Page<BlobChangeFeedEvent>> GetPage(
            bool async,
            int pageSize = 512)
        {
            if (!_isInitalized)
            {
                if (async)
                {
                    await Initalize(async: true).ConfigureAwait(false);
                }
                else
                {
                    Initalize(async: false).EnsureCompleted();
                }
            }

            if (!HasNext())
            {
                throw new InvalidOperationException("Change feed doesn't have any more events");
            }

            // Get next page
            Page<BlobChangeFeedEvent> page;

            //TODO what should we return here?  Also do we really need to check this on every page?
            if (_currentSegment.DateTime > _endTime)
            {
                return new BlobChangeFeedEventPage();
            }

            //TODO what should we return here?  Also do we really need to check this on every page?
            if (_currentSegment.DateTime > _lastConsumable)
            {
                return new BlobChangeFeedEventPage();
            }

            if (async)
            {
                page = await _currentSegment.GetPage(async: true, pageSize).ConfigureAwait(false);
            }
            else
            {
                page = _currentSegment.GetPage(async: false, pageSize).EnsureCompleted();
            }

            // If the current segment is completed, remove it
            if (!_currentSegment.HasNext() && _segments.Count > 0)
            {
                _currentSegment = new Segment(_containerClient, _segments.Dequeue());
            }

            // If _segments is empty, refill it
            else if (_segments.Count == 0 && _years.Count > 0)
            {
                string yearPath = _years.Dequeue();

                // Get Segments for first year
                if (async)
                {
                    _segments = await GetSegmentsInYear(
                        async: true,
                        yearPath: yearPath,
                        startTime: _startTime,
                        endTime: _endTime)
                        .ConfigureAwait(false);
                }
                else
                {
                    _segments = GetSegmentsInYear(
                        async: false,
                        yearPath: yearPath,
                        startTime: _startTime,
                        endTime: _endTime)
                        .EnsureCompleted();
                }

                if (_segments.Count > 0)
                {
                    _currentSegment = new Segment(_containerClient, _segments.Dequeue());
                }
            }

            return page;
        }



        public bool HasNext()
        {
            if (!_isInitalized)
            {
                return true;
            }
            if (_segments.Count == 0 && _years.Count == 0  && !_currentSegment.HasNext())
            {
                return false;
            }

            DateTimeOffset end = MinDateTime(_lastConsumable, _endTime);

            return _currentSegment.DateTime <= end;
        }

        //TODO how do update this?
        public DateTimeOffset LastConsumable()
        {
            return _lastConsumable;
        }

        public BlobChangeFeedCursor GetCursor()
            => new BlobChangeFeedCursor(
                urlHash: _containerClient.Uri.ToString().GetHashCode(),
                endDateTime: _endTime,
                currentSegmentCursor: _currentSegment.GetCursor());

        private async Task<Queue<string>> GetSegmentsInYear(
            bool async,
            string yearPath,
            DateTimeOffset? startTime = default,
            DateTimeOffset? endTime = default)
        {
            List<string> list = new List<string>();

            if (async)
            {
                await foreach (BlobHierarchyItem blobHierarchyItem in _containerClient.GetBlobsByHierarchyAsync(
                    prefix: yearPath)
                    .ConfigureAwait(false))
                {
                    if (blobHierarchyItem.IsPrefix)
                        continue;

                    DateTimeOffset segmentDateTime = blobHierarchyItem.Blob.Name.ToDateTimeOffset();
                    if (startTime.HasValue && segmentDateTime < startTime
                        || endTime.HasValue && segmentDateTime > endTime)
                        continue;

                    list.Add(blobHierarchyItem.Blob.Name);
                }
            }
            else
            {
                foreach (BlobHierarchyItem blobHierarchyItem in _containerClient.GetBlobsByHierarchy(
                    prefix: yearPath))
                {
                    if (blobHierarchyItem.IsPrefix)
                        continue;

                    DateTimeOffset segmentDateTime = blobHierarchyItem.Blob.Name.ToDateTimeOffset();
                    if (startTime.HasValue && segmentDateTime < startTime
                        || endTime.HasValue && segmentDateTime > endTime)
                        continue;

                    list.Add(blobHierarchyItem.Blob.Name);
                }
            }

            return new Queue<string>(list);
        }

        private async Task<Queue<string>> GetYearPaths(bool async)
        {
            List<string> list = new List<string>();

            if (async)
            {
                await foreach (BlobHierarchyItem blobHierarchyItem in _containerClient.GetBlobsByHierarchyAsync(
                    prefix: Constants.ChangeFeed.SegmentPrefix,
                    delimiter: "/").ConfigureAwait(false))
                {
                    if (blobHierarchyItem.Prefix.Contains(Constants.ChangeFeed.InitalizationSegment))
                        continue;

                    list.Add(blobHierarchyItem.Prefix);
                }
            }
            else
            {
                foreach (BlobHierarchyItem blobHierarchyItem in _containerClient.GetBlobsByHierarchy(
                prefix: Constants.ChangeFeed.SegmentPrefix,
                delimiter: "/"))
                {
                    if (blobHierarchyItem.Prefix.Contains(Constants.ChangeFeed.InitalizationSegment))
                        continue;

                    list.Add(blobHierarchyItem.Prefix);
                }
            }
            return new Queue<string>(list);
        }


        private static string BuildSegmentPath(
            int year,
            int? month = null,
            int? day = null,
            int? hour = null)
        {
            StringBuilder stringBuilder = new StringBuilder(Constants.ChangeFeed.SegmentPrefix);

            stringBuilder.Append(year + "/");

            if (month.HasValue)
            {
                stringBuilder.Append(month.Value + "/");
            }

            if (day.HasValue)
            {
                stringBuilder.Append(day.Value + "/");
            }

            if (hour.HasValue)
            {
                stringBuilder.Append(hour.Value + "/");
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Rounds a DateTimeOffset down to the nearest hour.
        /// </summary>
        private static DateTimeOffset? RoundHourDown(DateTimeOffset? dateTimeOffset)
        {
            if (dateTimeOffset == null)
            {
                return null;
            }

            return new DateTimeOffset(
                year: dateTimeOffset.Value.Year,
                month: dateTimeOffset.Value.Month,
                day: dateTimeOffset.Value.Day,
                hour: dateTimeOffset.Value.Hour,
                minute: 0,
                second: 0,
                offset: dateTimeOffset.Value.Offset);
        }

        /// <summary>
        /// Rounds a DateTimeOffset up to the nearest hour.
        /// </summary>
        private static DateTimeOffset? RoundHourUp(DateTimeOffset? dateTimeOffset)
        {
            if (dateTimeOffset == null)
            {
                return null;
            }

            DateTimeOffset? newDateTimeOffest = RoundHourDown(dateTimeOffset.Value);

            return newDateTimeOffest.Value.AddHours(1);
        }

        private static DateTimeOffset MinDateTime(DateTimeOffset lastConsumable, DateTimeOffset? endDate)
        {
            if (endDate.HasValue && endDate.Value < lastConsumable)
            {
                return endDate.Value;
            }

            return lastConsumable;
        }
    }
}

// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.CosmosDB
{
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Models;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// MongoDBResourcesOperations operations.
    /// </summary>
    public partial interface IMongoDBResourcesOperations
    {
        /// <summary>
        /// Lists the MongoDB databases under an existing Azure Cosmos DB
        /// database account.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Name of an Azure resource group.
        /// </param>
        /// <param name='accountName'>
        /// Cosmos DB database account name.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="Microsoft.Rest.Azure.CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<IEnumerable<MongoDBDatabaseGetResults>>> ListMongoDBDatabasesWithHttpMessagesAsync(string resourceGroupName, string accountName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Gets the MongoDB databases under an existing Azure Cosmos DB
        /// database account with the provided name.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Name of an Azure resource group.
        /// </param>
        /// <param name='accountName'>
        /// Cosmos DB database account name.
        /// </param>
        /// <param name='databaseName'>
        /// Cosmos DB database name.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="Microsoft.Rest.Azure.CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<MongoDBDatabaseGetResults>> GetMongoDBDatabaseWithHttpMessagesAsync(string resourceGroupName, string accountName, string databaseName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Create or updates Azure Cosmos DB MongoDB database
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Name of an Azure resource group.
        /// </param>
        /// <param name='accountName'>
        /// Cosmos DB database account name.
        /// </param>
        /// <param name='databaseName'>
        /// Cosmos DB database name.
        /// </param>
        /// <param name='createUpdateMongoDBDatabaseParameters'>
        /// The parameters to provide for the current MongoDB database.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="Microsoft.Rest.Azure.CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<MongoDBDatabaseGetResults>> CreateUpdateMongoDBDatabaseWithHttpMessagesAsync(string resourceGroupName, string accountName, string databaseName, MongoDBDatabaseCreateUpdateParameters createUpdateMongoDBDatabaseParameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Deletes an existing Azure Cosmos DB MongoDB database.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Name of an Azure resource group.
        /// </param>
        /// <param name='accountName'>
        /// Cosmos DB database account name.
        /// </param>
        /// <param name='databaseName'>
        /// Cosmos DB database name.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="Microsoft.Rest.Azure.CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse> DeleteMongoDBDatabaseWithHttpMessagesAsync(string resourceGroupName, string accountName, string databaseName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Gets the RUs per second of the MongoDB database under an existing
        /// Azure Cosmos DB database account with the provided name.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Name of an Azure resource group.
        /// </param>
        /// <param name='accountName'>
        /// Cosmos DB database account name.
        /// </param>
        /// <param name='databaseName'>
        /// Cosmos DB database name.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="Microsoft.Rest.Azure.CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<ThroughputSettingsGetResults>> GetMongoDBDatabaseThroughputWithHttpMessagesAsync(string resourceGroupName, string accountName, string databaseName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Update RUs per second of the an Azure Cosmos DB MongoDB database
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Name of an Azure resource group.
        /// </param>
        /// <param name='accountName'>
        /// Cosmos DB database account name.
        /// </param>
        /// <param name='databaseName'>
        /// Cosmos DB database name.
        /// </param>
        /// <param name='updateThroughputParameters'>
        /// The RUs per second of the parameters to provide for the current
        /// MongoDB database.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="Microsoft.Rest.Azure.CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<ThroughputSettingsGetResults>> UpdateMongoDBDatabaseThroughputWithHttpMessagesAsync(string resourceGroupName, string accountName, string databaseName, ThroughputSettingsUpdateParameters updateThroughputParameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Lists the MongoDB collection under an existing Azure Cosmos DB
        /// database account.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Name of an Azure resource group.
        /// </param>
        /// <param name='accountName'>
        /// Cosmos DB database account name.
        /// </param>
        /// <param name='databaseName'>
        /// Cosmos DB database name.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="Microsoft.Rest.Azure.CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<IEnumerable<MongoDBCollectionGetResults>>> ListMongoDBCollectionsWithHttpMessagesAsync(string resourceGroupName, string accountName, string databaseName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Gets the MongoDB collection under an existing Azure Cosmos DB
        /// database account.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Name of an Azure resource group.
        /// </param>
        /// <param name='accountName'>
        /// Cosmos DB database account name.
        /// </param>
        /// <param name='databaseName'>
        /// Cosmos DB database name.
        /// </param>
        /// <param name='collectionName'>
        /// Cosmos DB collection name.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="Microsoft.Rest.Azure.CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<MongoDBCollectionGetResults>> GetMongoDBCollectionWithHttpMessagesAsync(string resourceGroupName, string accountName, string databaseName, string collectionName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Create or update an Azure Cosmos DB MongoDB Collection
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Name of an Azure resource group.
        /// </param>
        /// <param name='accountName'>
        /// Cosmos DB database account name.
        /// </param>
        /// <param name='databaseName'>
        /// Cosmos DB database name.
        /// </param>
        /// <param name='collectionName'>
        /// Cosmos DB collection name.
        /// </param>
        /// <param name='createUpdateMongoDBCollectionParameters'>
        /// The parameters to provide for the current MongoDB Collection.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="Microsoft.Rest.Azure.CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<MongoDBCollectionGetResults>> CreateUpdateMongoDBCollectionWithHttpMessagesAsync(string resourceGroupName, string accountName, string databaseName, string collectionName, MongoDBCollectionCreateUpdateParameters createUpdateMongoDBCollectionParameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Deletes an existing Azure Cosmos DB MongoDB Collection.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Name of an Azure resource group.
        /// </param>
        /// <param name='accountName'>
        /// Cosmos DB database account name.
        /// </param>
        /// <param name='databaseName'>
        /// Cosmos DB database name.
        /// </param>
        /// <param name='collectionName'>
        /// Cosmos DB collection name.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="Microsoft.Rest.Azure.CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse> DeleteMongoDBCollectionWithHttpMessagesAsync(string resourceGroupName, string accountName, string databaseName, string collectionName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Gets the RUs per second of the MongoDB collection under an existing
        /// Azure Cosmos DB database account with the provided name.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Name of an Azure resource group.
        /// </param>
        /// <param name='accountName'>
        /// Cosmos DB database account name.
        /// </param>
        /// <param name='databaseName'>
        /// Cosmos DB database name.
        /// </param>
        /// <param name='collectionName'>
        /// Cosmos DB collection name.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="Microsoft.Rest.Azure.CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<ThroughputSettingsGetResults>> GetMongoDBCollectionThroughputWithHttpMessagesAsync(string resourceGroupName, string accountName, string databaseName, string collectionName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Update the RUs per second of an Azure Cosmos DB MongoDB collection
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Name of an Azure resource group.
        /// </param>
        /// <param name='accountName'>
        /// Cosmos DB database account name.
        /// </param>
        /// <param name='databaseName'>
        /// Cosmos DB database name.
        /// </param>
        /// <param name='collectionName'>
        /// Cosmos DB collection name.
        /// </param>
        /// <param name='updateThroughputParameters'>
        /// The RUs per second of the parameters to provide for the current
        /// MongoDB collection.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="Microsoft.Rest.Azure.CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<ThroughputSettingsGetResults>> UpdateMongoDBCollectionThroughputWithHttpMessagesAsync(string resourceGroupName, string accountName, string databaseName, string collectionName, ThroughputSettingsUpdateParameters updateThroughputParameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Create or updates Azure Cosmos DB MongoDB database
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Name of an Azure resource group.
        /// </param>
        /// <param name='accountName'>
        /// Cosmos DB database account name.
        /// </param>
        /// <param name='databaseName'>
        /// Cosmos DB database name.
        /// </param>
        /// <param name='createUpdateMongoDBDatabaseParameters'>
        /// The parameters to provide for the current MongoDB database.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="Microsoft.Rest.Azure.CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<MongoDBDatabaseGetResults>> BeginCreateUpdateMongoDBDatabaseWithHttpMessagesAsync(string resourceGroupName, string accountName, string databaseName, MongoDBDatabaseCreateUpdateParameters createUpdateMongoDBDatabaseParameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Deletes an existing Azure Cosmos DB MongoDB database.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Name of an Azure resource group.
        /// </param>
        /// <param name='accountName'>
        /// Cosmos DB database account name.
        /// </param>
        /// <param name='databaseName'>
        /// Cosmos DB database name.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="Microsoft.Rest.Azure.CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse> BeginDeleteMongoDBDatabaseWithHttpMessagesAsync(string resourceGroupName, string accountName, string databaseName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Update RUs per second of the an Azure Cosmos DB MongoDB database
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Name of an Azure resource group.
        /// </param>
        /// <param name='accountName'>
        /// Cosmos DB database account name.
        /// </param>
        /// <param name='databaseName'>
        /// Cosmos DB database name.
        /// </param>
        /// <param name='updateThroughputParameters'>
        /// The RUs per second of the parameters to provide for the current
        /// MongoDB database.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="Microsoft.Rest.Azure.CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<ThroughputSettingsGetResults>> BeginUpdateMongoDBDatabaseThroughputWithHttpMessagesAsync(string resourceGroupName, string accountName, string databaseName, ThroughputSettingsUpdateParameters updateThroughputParameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Create or update an Azure Cosmos DB MongoDB Collection
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Name of an Azure resource group.
        /// </param>
        /// <param name='accountName'>
        /// Cosmos DB database account name.
        /// </param>
        /// <param name='databaseName'>
        /// Cosmos DB database name.
        /// </param>
        /// <param name='collectionName'>
        /// Cosmos DB collection name.
        /// </param>
        /// <param name='createUpdateMongoDBCollectionParameters'>
        /// The parameters to provide for the current MongoDB Collection.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="Microsoft.Rest.Azure.CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<MongoDBCollectionGetResults>> BeginCreateUpdateMongoDBCollectionWithHttpMessagesAsync(string resourceGroupName, string accountName, string databaseName, string collectionName, MongoDBCollectionCreateUpdateParameters createUpdateMongoDBCollectionParameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Deletes an existing Azure Cosmos DB MongoDB Collection.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Name of an Azure resource group.
        /// </param>
        /// <param name='accountName'>
        /// Cosmos DB database account name.
        /// </param>
        /// <param name='databaseName'>
        /// Cosmos DB database name.
        /// </param>
        /// <param name='collectionName'>
        /// Cosmos DB collection name.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="Microsoft.Rest.Azure.CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse> BeginDeleteMongoDBCollectionWithHttpMessagesAsync(string resourceGroupName, string accountName, string databaseName, string collectionName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Update the RUs per second of an Azure Cosmos DB MongoDB collection
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Name of an Azure resource group.
        /// </param>
        /// <param name='accountName'>
        /// Cosmos DB database account name.
        /// </param>
        /// <param name='databaseName'>
        /// Cosmos DB database name.
        /// </param>
        /// <param name='collectionName'>
        /// Cosmos DB collection name.
        /// </param>
        /// <param name='updateThroughputParameters'>
        /// The RUs per second of the parameters to provide for the current
        /// MongoDB collection.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="Microsoft.Rest.Azure.CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<ThroughputSettingsGetResults>> BeginUpdateMongoDBCollectionThroughputWithHttpMessagesAsync(string resourceGroupName, string accountName, string databaseName, string collectionName, ThroughputSettingsUpdateParameters updateThroughputParameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}

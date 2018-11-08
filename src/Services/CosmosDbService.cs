namespace CosmosWebSample.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using CosmosWebSample.Models;
    using Microsoft.Azure.Cosmos;
    using Microsoft.Extensions.Configuration;

    public class CosmosDbService : ICosmosDbService
    {
        private readonly CosmosDbSettings _settings;
        private CosmosContainer _container;
        private CosmosClient _dbClient;

        public CosmosDbService(IConfigurationSection configuration)
        {
            this._settings = new CosmosDbSettings(configuration);
            var config = new CosmosConfiguration(_settings.DatabaseUri, _settings.DatabaseKey);
            config.UseConnectionModeDirect();
            this._dbClient = new CosmosClient(config);
        }

        public async Task InitializeAsync()
        {
            CosmosDatabaseResponse databaseResponse = await _dbClient.Databases.CreateDatabaseIfNotExistsAsync(_settings.DatabaseName);
            CosmosDatabase database = databaseResponse.Database;
            this._container = await database.Containers.CreateContainerIfNotExistsAsync(_settings.ContainerName, "/id");
        }
        
        public async Task AddItemAsync(Item item)
        {
            await _container.Items.CreateItemAsync<Item>(item.Id, item);
        }

        public async Task DeleteItemAsync(string id)
        {
            await _container.Items.DeleteItemAsync<Item>(id, id);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            var response = await _container.Items.ReadItemAsync<Item>(id, id);
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }

            return response.Resource;
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(string queryString)
        {
            var query = _container.Items.CreateItemQuery<Item>(new CosmosSqlQueryDefinition(queryString), maxConcurrency: 1);
            List<Item> results = new List<Item>();
            while (query.HasMoreResults)
            {
                var response = await query.FetchNextSetAsync();
                
                results.AddRange(response.ToList());
            }

            return results;
        }

        public async Task UpdateItemAsync(string id, Item item)
        {
            await _container.Items.UpsertItemAsync<Item>(id, item);
        }
    }
}

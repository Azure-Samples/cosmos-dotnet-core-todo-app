namespace todo.Services
{
    using Azure.Cosmos;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using todo.Models;

    public class CosmosDbService : ICosmosDbService
    {
        private readonly CosmosContainer _cosmosContainer;

        public CosmosDbService(CosmosClient dbClient, string databaseName, string containerName)
        {
            this._cosmosContainer = dbClient.GetContainer(databaseName, containerName);
        }

        public async Task AddItemAsync(Item item)
        {
            await this._cosmosContainer.CreateItemAsync<Item>(item, new PartitionKey(item.Id));
        }

        public async Task DeleteItemAsync(string id)
        {
            await this._cosmosContainer.DeleteItemAsync<Item>(id, new PartitionKey(id));
        }

        public async Task<Item> GetItemAsync(string id)
        {
            try
            {
                ItemResponse<Item> response = await this._cosmosContainer.ReadItemAsync<Item>(id, new PartitionKey(id));
                return response;
            }
            catch (CosmosException ex) when (ex.Status == (int)System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(string queryString)
        {
            QueryDefinition queryDefinition = new QueryDefinition(queryString);

            List<Item> results = new List<Item>();

            await foreach (Item item in _cosmosContainer.GetItemQueryIterator<Item>(queryDefinition))
            {
                results.Add(item);
            }

            return results;
        }

        public async Task UpdateItemAsync(Item item)
        {
            await this._cosmosContainer.UpsertItemAsync<Item>(item, new PartitionKey(item.Id));
        }
    }
}
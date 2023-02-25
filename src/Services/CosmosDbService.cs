namespace todo
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using todo.Models;
    using Microsoft.Azure.Cosmos;

    public class CosmosDbService : ICosmosDbService
    {
        private Container _container;

        public CosmosDbService(
            CosmosClient dbClient,
            string databaseName,
            string containerName)
        {
            this._container = dbClient.GetContainer(databaseName, containerName);
        }
        
        public async Task AddItemAsync(Item item)
        {
            await this._container.CreateItemAsync<Item>(item, new PartitionKey(item.Id));
        }

        public async Task DeleteItemAsync(string id)
        {
            await this._container.DeleteItemAsync<Item>(id, new PartitionKey(id));
        }

        public async Task<Item> GetItemAsync(string id)
        {
            try
            {
                ItemResponse<Item> response = await this._container.ReadItemAsync<Item>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch(CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            { 
                return null;
            }

        }

        public async IAsyncEnumerable<Item> GetItemsAsync(string query)
        {
            FeedIterator<Item> resultSetIterator = _container.GetItemQueryIterator<Item>(new QueryDefinition(query));

            while (resultSetIterator.HasMoreResults)
            {
                var feedResponse = await resultSetIterator.ReadNextAsync();

                foreach (var item in feedResponse)
                {
                    yield return item;
                }
            }
        }

        public async Task UpdateItemAsync(string id, Item item)
        {
            await this._container.UpsertItemAsync<Item>(item, new PartitionKey(id));
        }
    }
}

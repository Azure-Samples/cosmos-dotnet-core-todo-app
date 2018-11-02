namespace CosmosWebSample.Models
{
    using System;
    using Microsoft.Extensions.Configuration;

    public class CosmosDbSettings
    {
        public CosmosDbSettings(IConfiguration configuration)
        {
            try
            {
                DatabaseName = configuration.GetSection("DatabaseName").Value;
                ContainerName = configuration.GetSection("ContainerName").Value;
                DatabaseUri = configuration.GetSection("Account").Value;
                DatabaseKey = configuration.GetSection("Key").Value;
            }
            catch
            {
                throw new MissingFieldException("IConfiguration missing a valid Azure Cosmos DB field appsettings.json");
            }
        }

        public string DatabaseName { get; private set; }

        public string ContainerName { get; private set; }

        public string DatabaseUri { get; private set; }
        public string DatabaseKey { get; private set; }
    }
}

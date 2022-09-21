---
page_type: sample
languages:
- csharp
products:
- aspnet-core
- azure-cosmos-db
description: "This sample shows you how to use the Microsoft Azure Cosmos DB service to store and access data from an ASP.NET Core MVC application."
---

# Web application development with ASP.NET Core MVC using Azure Cosmos DB

This sample shows you how to use the Microsoft Azure Cosmos DB service to store and access data from an ASP.NET Core MVC application hosted on Azure App Service or running locally in your computer.

## Running this sample in Visual Studio

1. Before you can run this sample, you must have the following prerequisites:
    - Visual Studio 2017 (or higher).
    - An active Azure Cosmos account or the [Azure Cosmos DB Emulator](https://docs.microsoft.com/azure/cosmos-db/local-emulator) - If you don't have an account, refer to the [Create a database account](https://docs.microsoft.com/azure/cosmos-db/create-sql-api-dotnet#create-an-azure-cosmos-db-account) article

2. Clone this repository using Git for Windows (http://www.git-scm.com/), or download the zip file.

3. From Visual Studio, open the [todo.csproj](./src/todo.csproj).

4. In Visual Studio Build menu, select **Build Solution** (or Press F6). 

5. Retrieve the URI and PRIMARY KEY (or SECONDARY KEY) values from the Keys blade of your Azure Cosmos account in the Azure portal. For more information on obtaining endpoint & keys for your Azure Cosmos account refer to [View, copy, and regenerate access keys and passwords](https://docs.microsoft.com/azure/cosmos-db/secure-access-to-data#master-keys)  **if you are going to work with a real Azure Cosmos account**.
    * The default configuration is setup to work with a local Azure Cosmos DB Emulator.

6. In the [appsettings.json](./src/appsettings.json) file, located in the project root, find **Account** and **Key** and replace the placeholder values with the values obtained for your account if you are going to work with a real Azure Cosmos account.

7. You can now run and debug the application locally by pressing **F5** in Visual Studio.

### Deploy this sample to Azure in Visual Studio

1. In Visual Studio Solution Explorer, right-click on the project name and select **Publish...**

2. Using the *Pick a publish target* dialog, select **App Service**

3. Either select an existing App Service, or follow the prompts to create new one. Note: If you choose to create a new one, the App Name chosen must be globally unique. 

4. Once you have selected the App Service, click **Publish**

5. After a short time, Visual Studio will complete the deployment.

6. After deployment, go you your Web App in the Azure Portal and make sure to [add the App Settings](https://docs.microsoft.com/azure/app-service/configure-common#configure-app-settings):
    1. `CosmosDb:Account`: The endpoint for the Azure Cosmos account.
    1. `CosmosDb:Key`: The key for the Azure Cosmos account.
    1. `CosmosDb:DatabaseName`: The name of the Azure Cosmos database to use.
    1. `CosmosDb:ContainerName`: The name of the Azure Cosmos container to use.

For additional ways to deploy this web application to Azure, please refer to the [Deploy ASP.NET Core apps to Azure App Service](https://docs.microsoft.com/aspnet/core/host-and-deploy/azure-apps/?view=aspnetcore-2.2) article which includes information on using Azure Pipelines, CLI, and many more. 


## Running this sample from the .NET Core command line

1. Before you can run this sample, you must have the following prerequisites:
    - [.NET Core SDK 3.1 or higher](https://dotnet.microsoft.com/download)
    - An active Azure Cosmos account or the [Azure Cosmos DB Emulator](https://docs.microsoft.com/azure/cosmos-db/local-emulator) - If you don't have an account, refer to the [Create a database account](https://docs.microsoft.com/azure/cosmos-db/create-sql-api-dotnet#create-an-azure-cosmos-db-account) article

2. Clone this repository using your Git command line, or download the zip file.

3. Go to the location of the [todo.csproj](./src/todo.csproj) in your command line prompt.

4. Run `dotnet build` to restore packages and build the project.

5. Retrieve the URI and PRIMARY KEY (or SECONDARY KEY) values from the Keys blade of your Azure Cosmos account in the Azure portal. For more information on obtaining endpoint & keys for your Azure Cosmos account refer to [View, copy, and regenerate access keys and passwords](https://docs.microsoft.com/azure/cosmos-db/secure-access-to-data#master-keys) **if you are going to work with a real Azure Cosmos account**.
    * The default configuration is setup to work with a local Azure Cosmos DB Emulator.

6. In the [appsettings.json](./src/appsettings.json) file, located in the project root, find **Account** and **Key** and replace the placeholder values with the values obtained for your account if you are going to work with a real Azure Cosmos account.

7. You can now run and debug the application locally by running `dotnet run` and browsing the Url provided by the .NET Core command line.

### Deploy this sample to Azure with Visual Studio Code

1. Install the [Visual Studio Code extension](https://code.visualstudio.com/tutorials/app-service-extension/getting-started#_install-the-extension).

2. Sign in to your Azure account.

3. Click on the [Deploy](https://code.visualstudio.com/tutorials/app-service-extension/deploy-app) button on the Azure App Service extension.

4. Select the `src` folder to deploy. 

5. Select your Azure subscription and whether you want to select an existing Web App or create a new one. Note: If you choose to create a new one, the App Name chosen must be globally unique. 

6. After a short time, Visual Studio Code will complete the deployment.

7. After deployment, go you your Web App in the Azure Portal and make sure to [add the App Settings](https://docs.microsoft.com/azure/app-service/configure-common#configure-app-settings):
    1. `CosmosDb:Account`: The endpoint for the Azure Cosmos account.
    1. `CosmosDb:Key`: The key for the Azure Cosmos account.
    1. `CosmosDb:DatabaseName`: The name of the Azure Cosmos database to use.
    1. `CosmosDb:ContainerName`: The name of the Azure Cosmos container to use.

For additional ways to deploy this web application to Azure, please refer to [Deploy to Azure using App Service](https://code.visualstudio.com/tutorials/app-service-extension/getting-started) or [Deploy to Azure using the Azure CLI](https://code.visualstudio.com/tutorials/nodejs-deployment/getting-started).


## About the code
The code included in this sample is intended to get you going with a simple ASP.NET Core MVC application that connects to Azure Cosmos DB. It is not intended to be a set of best practices on how to build scalable enterprise grade web applications. This is beyond the scope of this quick start sample. 

## More information

- [Azure Cosmos DB Documentation](https://docs.microsoft.com/azure/cosmos-db)
- [Azure Cosmos DB .NET SDK](https://docs.microsoft.com/azure/cosmos-db/sql-api-sdk-dotnet)
- [Azure Cosmos DB .NET SDK Reference Documentation](https://docs.microsoft.com/dotnet/api/overview/azure/cosmosdb?view=azure-dotnet)

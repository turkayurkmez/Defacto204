// See https://aka.ms/new-console-template for more information
using Microsoft.Azure.Cosmos;
using usingCosmosDb;

Console.WriteLine("Hello, World!");
var databaseName = "samplecontainer";
var containerName = "sampleId";
var accountUrl = "https://badeo-cosmos-account.documents.azure.com:443/";
var key = "t8leOau7a5IvYGJvRxHaEtZmpHGvIuhQpLUHOnhY1qRIwUrSavY1tQbIJ1RaESqAGCVAub19K4UfgkwoQeAwIA==";
var cosmosClient = new CosmosClient(accountUrl, key);
var cosmosService = new CosmosDbService(cosmosClient, databaseName, containerName);

var employees = await cosmosService.GetEmployeesAsync();


employees.ToList().ForEach(e => Console.WriteLine($"{e.Name} {e.Lastname}"));


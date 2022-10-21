using Microsoft.Azure.Cosmos;

namespace usingCosmosDb
{

    public class CosmosDbService
    {

        private Container container;
        public CosmosDbService(CosmosClient client, string databaseName, string containerName)
        {
            container = client.GetContainer(databaseName, containerName);
        }
        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            var query = container.GetItemQueryIterator<Employee>("Select * from c");
            var result = new List<Employee>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                result.AddRange(response.ToList());
            }
            return result;
        }
    }
}

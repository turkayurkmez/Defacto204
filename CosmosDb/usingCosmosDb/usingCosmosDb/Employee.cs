using Newtonsoft.Json;

namespace usingCosmosDb
{

    public class Employee
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "employeeId")]
        public string EmployeeId { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "lastname")]
        public string Lastname { get; set; }
        [JsonProperty(PropertyName = "age")]

        public string Age { get; set; }

    }

}

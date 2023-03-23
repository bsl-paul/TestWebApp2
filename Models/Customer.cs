using System.Text.Json.Serialization;
namespace TestWebApp2.Models
{
    public class Customer
    {
        [JsonPropertyName("number")]
        public string Code { get; set; }
        [JsonPropertyName("displayName")]
        public string Name { get; set; }
    }

    public class CustomerRoot
    {
        [JsonPropertyName("@odata.context")]
        public string odatacontext { get; set; }
        [JsonPropertyName("value")]
        public List<Customer> value { get; set; }
    }
}



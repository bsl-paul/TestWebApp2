using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using TestWebApp2.Models;

namespace TestWebApp2.Entity;

public class BCCustomerRepository : ICustomerRepository
{
    AccessTokenProvider accessTokenProvider = AccessTokenProvider.Instance;

    public Customer GetCustomer(string code)
    {
        String url = @"https://api.businesscentral.dynamics.com/v2.0/production/api/v2.0/companies(2ccf1a8b-15ab-ec11-bb8a-000d3a2a8318)/customers?$format=xml";
        HttpClient client = new();
        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessTokenProvider.GetAccessToken().AccessToken}");
        client.DefaultRequestHeaders.Add("Data-Access-Intent", "ReadOnly");
        var result = client.GetAsync(url).Result;
        var response = result.Content.ReadAsStringAsync().Result;
        var customers = JsonSerializer.Deserialize<CustomerRoot>(response);
        
        return new Customer();
    }

    public IEnumerable<Customer> GetCustomers()
    {
        throw new NotImplementedException();
    }
}
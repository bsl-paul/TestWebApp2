using TestWebApp2.Models;

namespace TestWebApp2.Entity;

public class BCCustomerRepository : ICustomerRepository
{
    AccessTokenProvider accessTokenProvider = AccessTokenProvider.Instance;

    public Customer GetCustomer(string code)
    {
        String url = @"https://https://api.businesscentral.dynamics.com/v2.0/production/api/v2.0/customers";
        HttpClient client = new();
        client.DefaultRequestHeaders.Add("Authorization",$"Bearer {accessTokenProvider.GetToken().AccessToken}");
        var result = client.GetAsync(url).Result;
        Console.Write(result);
        return new Customer();
    }

    public IEnumerable<Customer> GetCustomers()
    {
        throw new NotImplementedException();
    }
}
using TestWebApp2.Models;

namespace TestWebApp2.Entity;
public interface ICustomerRepository
{
    IEnumerable<Customer> GetCustomers();
    Customer GetCustomer(string code);
}
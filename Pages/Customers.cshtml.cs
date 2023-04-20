using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestWebApp2.Entity;
using TestWebApp2.Models;

namespace TestWebApp2.Pages;

public class CustomerModel : PageModel
{
    public List<Customer>? Customers { get; set; }
    private ICustomerRepository CustomerRepository;
    private IConfiguration _configuration;
    public CustomerModel(IConfiguration configuration)
    {
        CustomerRepository = new BCCustomerRepository();
        _configuration = configuration;
    }

    public void OnGet()
    {
        Customers = CustomerRepository.GetCustomers().ToList();
        ViewData.Add("TESTCONFIG",_configuration["BusinessCentral:BaseURL"]);
    }
    public PartialViewResult OnGetCustomerListPartial()
    {        
        Customers = CustomerRepository.GetCustomers().ToList();        
        return Partial("CustomerListPartial", Customers);
    }
}
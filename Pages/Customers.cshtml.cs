using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestWebApp2.Entity;
using TestWebApp2.Models;

namespace TestWebApp2.Pages;

public class CustomerModel : PageModel
{
    public List<Customer>? Customers { get; set; }
    private ICustomerRepository CustomerRepository;
    public CustomerModel()
    {
        CustomerRepository = new BCCustomerRepository();
    }

    public void OnGet()
    {
        Customers = CustomerRepository.GetCustomers().ToList();
    }
    public PartialViewResult OnGetCustomerListPartial()
    {
        Customers = CustomerRepository.GetCustomers().ToList();
        return Partial("CustomerListPartial", Customers);
    }
}
using CustomersApp.Models.DTOs;

namespace CustomersApp.Models.Interfaces
{
    public interface ICustomer
    {
       Task<bool> AddCustomer(CreateCustomer createCustomer);
       Task<List<Customer>> GetAll();
        Task<Customer> GetCustomerById(int id);
       Task<bool> RemoveCustomer(int id);
       Task<bool> UpdateCustomer(Customer customer);

    }
}

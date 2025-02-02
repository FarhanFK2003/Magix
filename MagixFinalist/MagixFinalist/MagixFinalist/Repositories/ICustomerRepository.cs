using System.Collections.Generic;
using MagixFinalist.Models;

namespace MagixFinalist.Repositories
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);
        void AddCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(int id);
        Customer GetCustomerByEmail(string email);
        Customer AuthenticateCustomer(string email, string password);
    }
}
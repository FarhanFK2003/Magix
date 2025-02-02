using MagixFinalist.Models;
using MagixFinalist.Repositories;

namespace MagixFinalist.Services
{
    public class CustomersService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomersService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _customerRepository.GetAllCustomers();
        }

        public Customer GetCustomerById(int id)
        {
            return _customerRepository.GetCustomerById(id);
        }

        public void AddCustomer(Customer customer)
        {
            _customerRepository.AddCustomer(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            _customerRepository.UpdateCustomer(customer);
        }

        public void DeleteCustomer(int id)
        {
            _customerRepository.DeleteCustomer(id);
        }

        public Customer GetCustomerByEmail(string email)
        {
            return _customerRepository.GetCustomerByEmail(email);
        }

        public Customer AuthenticateCustomer(string email, string password)
        {
            return _customerRepository.AuthenticateCustomer(email, password);
        }
    }
}
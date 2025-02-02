using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics.Metrics;
using System;
using MagixFinalist.Models;

namespace MagixFinalist.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MagixDB;Integrated Security=True;";

        // Constructor to initialize the repository with a connection string
        public CustomerRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Creates and returns a new SQL connection object
        private IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

        // Function to get all customers
        public IEnumerable<Customer> GetAllCustomers()
        {
            using (var connection = CreateConnection())
            {
                // SQL query to fetch all customers
                string query = "SELECT * FROM Customer";
                return connection.Query<Customer>(query);
            }
        }

        // Function to get a customer by ID
        public Customer GetCustomerById(int id)
        {
            using (var connection = CreateConnection())
            {
                // SQL query to fetch customer details by ID
                string query = "SELECT * FROM Customer WHERE Id = @Id";
                return connection.QueryFirstOrDefault<Customer>(query, new { Id = id });
            }
        }

        // Function to add a customer
        public void AddCustomer(Customer customer)
        {
            using (var connection = CreateConnection())
            {
                // SQL query to insert a new customer
                string query = "INSERT INTO Customer (Email, Password) VALUES (@Email, @Password)";
                connection.Execute(query, customer);
            }
        }

        // Function to update a customer
        public void UpdateCustomer(Customer customer)
        {
            using (var connection = CreateConnection())
            {
                // SQL query to update a customer's details
                string query = "UPDATE Customer SET Email = @Email, Password = @Password WHERE Id = @Id";
                connection.Execute(query, customer);
            }
        }

        // Function to delete a customer
        public void DeleteCustomer(int id)
        {
            using (var connection = CreateConnection())
            {
                // SQL query to delete a customer by ID
                string query = "DELETE FROM Customer WHERE Id = @Id";
                connection.Execute(query, new { Id = id });
            }
        }

        public bool IsEmailExists(string email)
        {
            using (var connection = CreateConnection())
            {
                string query = "SELECT COUNT(1) FROM Customer WHERE Email = @Email";
                return connection.ExecuteScalar<int>(query, new { Email = email }) > 0;
            }
        }

        // Method to get customer by email
        public Customer GetCustomerByEmail(string email)
        {
            using (var connection = CreateConnection())
            {
                string query = "SELECT * FROM Customer WHERE Email = @Email";
                return connection.QueryFirstOrDefault<Customer>(query, new { Email = email });
            }
        }

        // Method to authenticate customer by email and password
        public Customer AuthenticateCustomer(string email, string password)
        {
            using (var connection = CreateConnection())
            {
                string query = "SELECT * FROM Customer WHERE Email = @Email AND Password = @Password";
                return connection.QueryFirstOrDefault<Customer>(query, new { Email = email, Password = password });
            }
        }

    }
}

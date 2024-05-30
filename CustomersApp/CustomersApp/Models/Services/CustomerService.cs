using CustomersApp.Data;
using CustomersApp.Models.DTOs;
using CustomersApp.Models.Interfaces;
using Dapper;
using System.Data;

namespace CustomersApp.Models.Services
{
    public class CustomerService : ICustomer
    {
        private readonly DapperDbContext _context;
        public CustomerService(DapperDbContext context)
        {
            this._context = context;
        }
        public async Task<bool> AddCustomer(CreateCustomer createCustomer)
        {
            var query = "INSERT INTO Customers (Name, Phone, Email) VALUES (@Name, @Phone, @Email)";
            var parameters = new DynamicParameters();
            parameters.Add("name", createCustomer.Name,DbType.String);
            parameters.Add("Phone", createCustomer.Phone, DbType.String);
            parameters.Add("Email", createCustomer.Email, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                var result= await connection.ExecuteAsync(query, parameters);
                if (result == 1) return true;
            }
            
            return false;
        }

        public async Task<List<Customer>> GetAll()
        {
            var query = "SELECT * FROM Customers";
            using (var connection = _context.CreateConnection())
            {
                var customers= await connection.QueryAsync<Customer>(query);
                return customers.ToList();
            }
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            var query = "SELECT * FROM Customers WHERE Id=@Id";
            using (var connection = _context.CreateConnection())
            {
                var customer = await connection.QueryFirstOrDefaultAsync<Customer>(query, new {Id=id});
                return customer;
            }
        }

        public async Task<bool> RemoveCustomer(int id)
        {
            var query = "DELETE FROM Customers WHERE Id = @Id";

            using (var connection = _context.CreateConnection())
            {
                var rowsAffected = await connection.ExecuteAsync(query, new { Id = id });
                return rowsAffected > 0;
            }
        }

        public async Task<bool> UpdateCustomer(Customer customer)
        {
            var query = @"UPDATE Customers 
                      SET Name = @Name, Phone = @Phone, Email = @Email 
                      WHERE Id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("name", customer.Name,DbType.String);
            parameters.Add("Phone", customer.Phone, DbType.String);
            parameters.Add("Email", customer.Email, DbType.String);
            parameters.Add("@Id", customer.Id);

            using (var connection = _context.CreateConnection())
            {
                var rowsAffected = await connection.ExecuteAsync(query,parameters);
                return rowsAffected > 0;
            }
        }
    }
}

using CustomersApp.Models;
using CustomersApp.Models.DTOs;
using CustomersApp.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomersApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomer _context;
        public CustomersController(ICustomer context)
        {
            this._context = context;
        }

        [Route("GetAll")]
        [Authorize]
        [HttpGet] 
        public async Task<List<Customer>> GetAll() {
          
        return await _context.GetAll(); 
        }
        [Route("GetById/{id}")]

        [HttpGet]
        [Authorize]

        public async Task<Customer> GetCustomer(int id)
        {

            return await _context.GetCustomerById(id);
        }

        [Route("Create/Customer")]
        [Authorize]

        [HttpPost]
        public async Task<bool> Create(Customer customer)
        {

            var createCustomer = (CreateCustomer)customer;
            return await _context.AddCustomer(createCustomer);
        }
        [Route("update/Customer/{id}")]
        [Authorize]

        [HttpPut]
        public async Task<bool> Update(int id,[FromBody]Customer customer)
        {
            customer.Id = id;
            return await _context.UpdateCustomer(customer);
        }

        [Route("Remove/{id}")]
        [Authorize]

        [HttpDelete]
        public async Task<bool> Remove(int id)
        {

            return await _context.RemoveCustomer(id);
        }
    }

}

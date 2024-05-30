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
        public async Task<bool> Create(CreateCustomer createCustomer)
        {

            return await _context.AddCustomer(createCustomer);
        }
        [Route("update/Customer")]
        [Authorize]

        [HttpPut]
        public async Task<bool> Update(Customer customer)
        {

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

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
    public class UsersController : ControllerBase
    {
        private readonly IUser _user;
        public UsersController(IUser user) {
        
            _user = user;   
        }

        [Route("login")]

        [HttpPost]
        public  string Create(User user)
        {

            return  _user.login(user);
        }
    }
}

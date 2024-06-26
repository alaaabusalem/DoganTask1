﻿using CustomersApp.Models;
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
        public IActionResult Login(User user)
        {

            var token = _user.login(user);
            if(token== "Wrong Name OR Passowred")
                return Unauthorized();

            return Ok(token);
        }
    }
}

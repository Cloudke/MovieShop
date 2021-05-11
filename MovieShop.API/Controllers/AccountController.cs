using ApplicationCore.Models.Request;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        public AccountController(IUserService userService)

        {
            _userService = userService;
        }

        [HttpGet]
        [Route("{id:int}", Name = "GetUser")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);
            return Ok(user);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Register(UserRegisterRequestModel model)
        {
            var user = await _userService.RegisterUser(model);
            //201
            return CreatedAtRoute("GetUser",new { id = user.Id },user);
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllUsers()
        {
            var user = await _userService.GetAllUsers();
            return Ok(user);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(UserLoginRequestModel user)
        {
            var dbuser = await _userService.ValidateUser(user.Email,user.Password);
            if(dbuser == null)
            {
                return NotFound("Email not exist,Please register ");
            }
            
            return CreatedAtRoute("GetUser", new { id = dbuser.Id}, dbuser);
        }
    }
}

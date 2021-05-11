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
    public class AdminController : ControllerBase
    {
        private readonly IUserService _userService;
        public AdminController(IUserService userService)

        {
            _userService = userService;
        }
        [HttpGet]
        [Route("purchases")]
        public async Task<IActionResult> GetAllPurchases()
        {
            var movies = await _userService.GetAllUsers();
            return Ok(movies);
        }
    }
}

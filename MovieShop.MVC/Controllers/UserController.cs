using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IUserService _userService;

        public UserController(IUserService userService, IMovieService movieService)
        {
            _userService = userService;
            _movieService = movieService;
        }

        public async Task<IActionResult> GetUserPurchase(int id)
        {
            // call the user service with userid and get 
            // it should check for cookie and cookie should not be expired
            var movie = await _movieService.GetMovieByIdAsync(id);
            return View(movie);
        }

        [Authorize]
        public async Task<IActionResult> Purchases()
        {
            return View();
        }
    }
}

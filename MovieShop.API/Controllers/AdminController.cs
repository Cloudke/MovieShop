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
    public class AdminController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMovieService _movieService;
        public AdminController(IUserService userService, IMovieService movieService)
        {
            _movieService = movieService;
            _userService = userService;
        }

        [HttpPost]
        [Route("movie")]
        public async Task<IActionResult> AddMovie(MovieCreateRequestModel request)
        {
            var movie = await _movieService.CreateMovie(request);
            //routename, routeid,object
            return CreatedAtRoute("GetMovieById",new { id=movie.Id},movie);
        }

        [HttpPut]
        [Route("movie")]
        public async Task<IActionResult> UpdateMovie(MovieCreateRequestModel request)
        {
            var movie = await _movieService.UpdateMovie(request);
            return CreatedAtRoute("GetMovieById", new { id = movie.Id }, movie);
        }

        [HttpGet]
        [Route("purchases")]
        public async Task<IActionResult> GetAllPurchases()
        {
            var purchases = await _movieService.GetAllPurchases();
            return Ok(purchases);
        }
    }
}

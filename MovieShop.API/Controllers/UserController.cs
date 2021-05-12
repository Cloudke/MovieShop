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
    public class UserController : ControllerBase

    {
        private readonly IUserService _userService;
        private readonly IMovieService _movieService;
        public UserController(IUserService userService, IMovieService movieService)
        {
            _userService = userService;
            _movieService = movieService;
        }

        [HttpPost]
        [Route("purchase")]
        public async Task<IActionResult> PurchaseMovie()
        {
            return Ok("");
        }

        [HttpPost]
        [Route("favorite")]
        public async Task<IActionResult> FavoriteMovie(int id)
        {
            return Ok("");
        }

        [HttpPost]
        [Route("unfavorite")]
        public async Task<IActionResult> UnfavoriteMovie(int id)
        {
            return Ok("");
        }

        [HttpGet]
        [Route("{id:int}/movie/{movieId:int}/favorite")]
        public async Task<IActionResult> CheckIsFavoritedMovie(int id,int movieId)
        {
            return Ok("");
        }

        [HttpPost]
        [Route("review")]
        public async Task<IActionResult> PostReview()
        {
            return Ok("");
        }

        [HttpPut]
        [Route("review")]
        public async Task<IActionResult> UpdateReview()
        {
            return Ok("");
        }


        [HttpGet]
        [Route("{id:int}/purchases")]
        public async Task<IActionResult> GetAllPurchasesForUser(int id)
        {
            var purchases = await _userService.GetAllPurchasesById(id);
            return Ok(purchases);
        }
        [HttpGet]
        [Route("{id:int}/favorites")]
        public async Task<IActionResult> GetUserfavorites(int id)
        {
            var movies = await _userService.GetAllFavorite(id);
            return Ok(movies);
        }
        [HttpGet]
        [Route("{id:int}/reviews")]
        public async Task<IActionResult> GetAllUserReviews(int id)
        {
            var user = await _userService.GetAllReviewsById(id);
            return Ok(user);
        }
    }
}

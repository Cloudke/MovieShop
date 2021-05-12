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
    public class UserController : ControllerBase

    {
        private readonly IUserService _userService;
        private readonly IMovieService _movieService;
        private readonly ICurrentUserService _currentUserService;
        public UserController(IUserService userService, IMovieService movieService, ICurrentUserService currentUserService)
        {
            _userService = userService;
            _movieService = movieService;
            _currentUserService = currentUserService;
        }

        [HttpPost]
        [Route("purchase")]
        public async Task<IActionResult> PurchaseMovie()
        {
            return Ok("");
        }

        [HttpPost]
        [Route("favorite")]
        public async Task<IActionResult> FavoriteMovie([FromBody] UserFavoriteRequestModel model)
        {
            model.UserId = (int)_currentUserService.UserId;
            var favorite = await _userService.FavoriteMovie(model.MovieId, model.UserId);
            if (favorite == null)
            {
               return NotFound("Failed to favorite the movie");
            }
            return Ok();
        }

        [HttpPost]
        [Route("unfavorite")]
        public async Task<IActionResult> UnfavoriteMovie(int movieId)
        {
            var result = await _userService.UnFavoriteMovie(movieId, (int)_currentUserService.UserId);
            if (result) { 
                return Ok(); 
            }
            return NotFound("Failed to unfavorite the movie");
        }

        [HttpGet]
        [Route("{id:int}/movie/{movieId:int}/favorite")]
        public async Task<IActionResult> CheckIsFavoritedMovie(int id,int movieId)
        {
            var isFavoritedMovie = await _userService.IsFavoritedMovieByUser(id, movieId);
            return Ok(isFavoritedMovie);
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

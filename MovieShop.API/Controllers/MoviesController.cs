using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MoviesController (IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllMovies()
        {
            var movies = await _movieService.GetAllMovies();
            if (movies.Any())
            {
                return Ok(movies);
            }
            else
                return NotFound("No movies found");
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetMovieById(int id)
        {
            var movie = await _movieService.GetMovieByIdAsync(id);
            if (movie != null)
            {
                return Ok(movie);
            }
            else
                return NotFound("No movies found");
        }

        [HttpGet]
        [Route("topRated")]
        public async Task<IActionResult> GetTopRated()
        {

            var movies = await _movieService.GetTop30RevenueMovie();
            if (movies.Any())
            {
                return Ok(movies);
            }
            else
                return NotFound("No movies found");
        }

        [HttpGet]
        [Route("topRevenue")]
        public async Task<IActionResult> GetTopRevenue()
        {

            var movies = await _movieService.GetTop30RevenueMovie();
            if (movies.Any())
            {
                return Ok(movies);
            }
            else
                return NotFound("No movies found");
        }

        [HttpGet]
        [Route("genre/{genreId:int}")]
        public async Task<IActionResult> GetMoviesByGenre(int genreId)
        {

            var movies = await _movieService.GetMoviesByGenreAsync(genreId);
            if (movies.Any())
            {
                return Ok(movies);
            }
            else
                return NotFound("No movies found");
        }

        [HttpGet]
        [Route("genre/{id:int}/reviews")]
        public async Task<IActionResult> GetMovieReviews(int id)
        {

            var reviews = await _movieService.GetMovieReviews(id);
            if (reviews.Any())
            {
                return Ok(reviews);
            }
            else
                return NotFound("No movies found");
        }
    }
}

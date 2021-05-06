using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.MVC.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public async Task<IActionResult> Details(int id)
        {
            //movie service to get details
            var movie = await _movieService.GetMovieByIdAsync(id);
            return View(movie);
        }

        public async Task<IActionResult> GetMoviesByGenre(int id)
        {
            // call my movie service to get the movies by genre
            var movies = await _movieService.GetMoviesByGenreAsync(id);
            return View("~/Views/Home/Index.cshtml", movies);
        }
    }
}

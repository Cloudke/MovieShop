using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.ServiceInterfaces;
using ApplicationCore.Models.Response;
using ApplicationCore.RepositoryInterfaces;

namespace Infrastructure.Services
{
    public class MovieService:IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly ICastRepository _castRepository;

        public MovieService (IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
  
        }

        //api/Movies
        public async Task<List<MovieCardResponseModel>> ListAllAsync()
        {
            var movies = await _movieRepository.ListAllAsync();
            var allMovies = new List<MovieCardResponseModel>();
            foreach (var movie in  movies)
            {
                allMovies.Add(new MovieCardResponseModel
                {
                    Id = movie.Id,
                    Budget = movie.Budget,
                    Title = movie.Title,
                    PosterUrl = movie.PosterUrl
                });
            }

            return allMovies;
        }

        public async Task<List<MovieCardResponseModel>> GetTop30RevenueMovie()
        {
            var movies = await _movieRepository.GetTop30HighestRevenueMovies();

            var topMovies = new List<MovieCardResponseModel>();
            foreach (var movie in movies)
            {
                topMovies.Add(new MovieCardResponseModel
                {
                    Id = movie.Id,
                    Budget = movie.Budget,
                    Title = movie.Title,
                    PosterUrl = movie.PosterUrl
                });
            }

            return topMovies;
        }

        //api/Movies/{id}

        public async Task<MovieDetailResponseModel> GetMovieByIdAsync(int id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);
            var genres = new List<GenreResponseModel>();

            foreach (var genre in movie.Genre)
            {
                genres.Add(new GenreResponseModel
                {
                    Id = genre.Id,
                    Name = genre.Name,

                });
            }
            var casts = new List<MovieDetailResponseModel.CastResponseModel>();
            foreach (var cast in movie.MovieCasts)
            {              
                casts.Add(new MovieDetailResponseModel.CastResponseModel
                {
                    Id = cast.Cast.Id,
                    Name = cast.Cast.Name,
                    Gender = cast.Cast.Gender,
                    TmdbUrl = cast.Cast.TmdbUrl,
                    ProfilePath = cast.Cast.ProfilePath,
                    Character = cast.Character,
                });
            }
            var result = new MovieDetailResponseModel
            {
                Id = movie.Id,
                Budget = movie.Budget,
                Title = movie.Title,
                Tagline = movie.Tagline,
                Overview = movie.Overview,
                RunTime = movie.RunTime,
                ReleaseDate = movie.ReleaseDate,
                BackdropUrl = movie.BackdropUrl,
                PosterUrl = movie.PosterUrl,
                Price = movie.Price,
                Rating = movie.Rating,
                Genres = genres,
                Casts = casts
            };
            return result;
        }


    //    api/Movies/genre/{genreId}
    public async Task<List<MovieCardResponseModel>> GetMoviesByGenreAsync(int id)
        {
            var movies = await _movieRepository.GetMoviesByGenreAsync(id);

            var total = new List<MovieCardResponseModel>();
            foreach (var movie in movies)
            {
                total.Add(new MovieCardResponseModel
                {
                    Id = movie.Id,
                    Budget = movie.Budget,
                    Title = movie.Title,
                    PosterUrl = movie.PosterUrl
                });
            }
            return total;
        }

    }
}

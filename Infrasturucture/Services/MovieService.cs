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
        public MovieService (IMovieRepository movieRepository, ICastRepository castRepository)
        {
            _movieRepository = movieRepository;
            _castRepository = castRepository;
        }
        public async Task<List<MovieResponseModel>> GetTop30RevenueMovie()
        {
            var movies = await _movieRepository.GetTop30HighestRevenueMovies();

            var topMovies = new List<MovieResponseModel>();
            foreach (var movie in movies)
            {
                topMovies.Add(new MovieResponseModel
                {
                    Id = movie.Id,
                    Budget = movie.Budget,
                    Title = movie.Title
                });
            }

            return topMovies;
        }

        public async Task<MovieResponseModel> GetByIdAsync(int id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);
            var movie2 = new MovieResponseModel { Id = movie.Id, Budget = movie.Budget, Title = movie.Title };
            return movie2;
        }

        public async Task<MovieCastRatingResponseModel> GetMovieByIdAsync(int id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);
            var casts = await _castRepository.GetByIdAsync(id);
            var totalCasts = new List<CastResponseModel>();
            foreach (var cast in totalCasts)
            {
                totalCasts.Add(new CastResponseModel
                {
                    Id = cast.Id,
                    Name = cast.Name,
                    Gender = cast.Gender,
                    TmdbUrl = cast.TmdbUrl,
                    ProfilePath = cast.ProfilePath
                });
               
            }

            var result = new MovieCastRatingResponseModel { Id = movie.Id, Budget = movie.Budget, Title = movie.Title,Casts =totalCasts };
            return result;
        }



    }
}

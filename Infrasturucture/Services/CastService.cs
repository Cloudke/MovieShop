using ApplicationCore.Models.Response;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class CastService:ICastService

    {
        private readonly ICastRepository _castRepository;
        private readonly IMovieRepository _movieRepository;
        public CastService( IMovieRepository movieRepository, ICastRepository castRepository)
        {
            _castRepository = castRepository;
            _movieRepository = movieRepository;
        }

        //get info of this cast only
        public async Task<CastResponseModel> GetById(int id)
        {
            var cast = await _castRepository.GetByIdAsync(id);
            return new CastResponseModel {Id=cast.Id,Name=cast.Name,Gender=cast.Gender,TmdbUrl=cast.TmdbUrl,ProfilePath=cast.ProfilePath };
        }


        //get info of this cast and movies
        public async Task<CastDetailResponseModel> GetCastById(int id)
        {
            var cast = await _castRepository.GetByIdAsync(id);
            var movies = new List<MovieCardResponseModel>();
            foreach (var movie in cast.MovieCasts)
            {
                var singleMovie = await _movieRepository.GetByIdAsync(movie.MovieId);
                movies.Add(new MovieCardResponseModel
                {
                    Id = singleMovie.Id,
                    Title = singleMovie.Title,
                    Budget = singleMovie.Budget,
                    PosterUrl = singleMovie.PosterUrl
                });
            }


            var result = new CastDetailResponseModel{ Id = cast.Id, Name = cast.Name, Gender = cast.Gender, TmdbUrl = cast.TmdbUrl, 
                                                       ProfilePath = cast.ProfilePath,Movies = movies } ;
            return result;
        }
    }
}

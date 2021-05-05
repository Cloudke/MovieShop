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
        public CastService(ICastRepository castRepository, IMovieRepository movieRepository)
        {
            _castRepository = castRepository;
            _movieRepository = movieRepository;
        }
        public async Task<CastMovieResponseModel> GetCastByIdAsync(int id)
        {
            var cast = await _castRepository.GetByIdAsync(id);
            //var movies = await _movieRepository
            var result = new CastMovieResponseModel{ } ;
            return result;
        }
    }
}

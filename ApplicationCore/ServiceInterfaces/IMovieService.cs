using ApplicationCore.Models.Response;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Models.Request;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IMovieService
    {
        Task<List<MovieCardResponseModel>> GetTop30RevenueMovie();
        Task<MovieDetailResponseModel> GetMovieByIdAsync(int id);
        Task<List<MovieCardResponseModel>> GetMoviesByGenreAsync(int id);
        Task<List<MovieCardResponseModel>> GetAllMovies();
        Task<List<MovieCardResponseModel>> GetTopRatedMovies();
        Task<List<ReviewResponseModel>> GetMovieReviews(int id);
        Task<List<MovieCardResponseModel>> GetAllPurchases();
        Task<MovieDetailResponseModel> CreateMovie(MovieCreateRequestModel request);
    }
}

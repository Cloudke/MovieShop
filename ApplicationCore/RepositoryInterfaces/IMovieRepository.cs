using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface IMovieRepository : IAsyncRepository<Movie>
    {
        Task<IEnumerable<Movie>> GetTop30HighestRevenueMovies();
        Task<IEnumerable<Movie>> GetAllMovies();
        Task<IEnumerable<Movie>> GetTopRatedMovies();
        Task<List<Movie>> GetMoviesByGenreAsync(int id);
        Task<List<Review>> GetMovieReviewsAsync(int id);

    }
}

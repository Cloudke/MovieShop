using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public class MovieRepository : EfRepository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        //api/Movies/{id}
        public override async Task<Movie> GetByIdAsync(int id)
        {

            //get movie detail+cast+genre
            //ThenInclude:drill down thru relationships to include multiple levels of related data using the ThenInclude method
            var movie = await _dbContext.Movie.Include(m => m.MovieCasts).ThenInclude(m => m.Cast)
                                .Include(m => m.Genre)
                                .FirstOrDefaultAsync(m => m.Id == id);

            //casts for movie
            //avg rating
            //genres
            //show watch button only when user logged in and purchased the movies otherwise show buy button
            //include, theninclude

            var rating = await _dbContext.Review.Where(r => r.MovieId == id).AverageAsync(r => r.Rating);
            //assign movie avg rating;
            movie.Rating = rating;
            return movie;
        }



        //api/Movies/toprated
        public async Task<IEnumerable<Movie>> GetTopRatedMoviesAsync()
        {
            var movies = await _dbContext.Movie.OrderByDescending(m => m.Rating).Take(30).ToListAsync();
            return movies;
        }

        //api/Movies/toprevenue
        public async Task<IEnumerable<Movie>> GetTop30HighestRevenueMovies()
        {
            var movies = await _dbContext.Movie.OrderByDescending(m => m.Revenue).Take(30).ToListAsync();
            return movies;
        }

        //api/Movies/genre/{genreId}
        public async Task<List<Movie>> GetMoviesByGenreAsync(int id)
        {
            var movie = await _dbContext.Genre.Include(m => m.Movies).Where(g => g.Id == id).SelectMany(m => m.Movies).ToListAsync();
            return movie;
        }

        //First()
        //FirstOrDefault()
        //Single()
        //SingleOrDefault()
        //Where()
        //GroupBy()
        //ToList()
        //Any()
    }
}

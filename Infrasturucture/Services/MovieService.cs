using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.ServiceInterfaces;
using ApplicationCore.Models.Response;
using ApplicationCore.Models.Request;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.Entities;

namespace Infrastructure.Services
{
    public class MovieService:IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IPurchaseRepository _purchaseRepository;

        public MovieService (IMovieRepository movieRepository, IPurchaseRepository purchaseRepository)
        {
            _movieRepository = movieRepository;
            _purchaseRepository = purchaseRepository;
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
                    PosterUrl = movie.PosterUrl,
                    Revenue = movie.Revenue
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
                ReleaseDate = movie.ReleaseDate.Value,
                Revenue = movie.Revenue,
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

        public async Task<List<MovieCardResponseModel>> GetAllMovies()
        {
            var dbmovies = await _movieRepository.GetAllMovies();
            var allMovies = new List<MovieCardResponseModel>();
            foreach (var movie in dbmovies)
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
        public async Task<List<MovieCardResponseModel>> GetTopRatedMovies()
        {
            var dbmovies = await _movieRepository.GetTopRatedMovies();
            var allMovies = new List<MovieCardResponseModel>();
            foreach (var movie in dbmovies)
            {
                allMovies.Add(new MovieCardResponseModel
                {
                    Id = movie.Id,
                    Budget = movie.Budget,
                    Title = movie.Title,
                    PosterUrl = movie.PosterUrl,
                });
            }

            return allMovies;
        }

        public async Task<List<ReviewResponseModel>> GetMovieReviews(int id)
        {
            var reviews = await _movieRepository.GetMovieReviewsAsync(id);
            var allReviews = new List<ReviewResponseModel>();
            foreach (var review in reviews)
            {
                allReviews.Add(new ReviewResponseModel
                {
                    UserId = review.UserId,
                    MovieId = review.MovieId,   
                    Title = review.Movie.Title,
                    Rating = review.Rating,
                    ReviewText = review.ReviewText
                });
            }
            return allReviews;
        }

        public async Task<List<MovieCardResponseModel>> GetAllPurchases()
        {
            var movies = await _purchaseRepository.GetAllPurchases();
            var allMovies = new List<MovieCardResponseModel>();
            foreach (var movie in movies)
            {
                allMovies.Add(new MovieCardResponseModel
                {
                    Id = movie.Movie.Id,
                    Budget = movie.Movie.Budget,
                    Title = movie.Movie.Title,
                    PosterUrl = movie.Movie.PosterUrl,
                });
            }

            return allMovies;
        }
        public async Task<MovieDetailResponseModel> CreateMovie(MovieCreateRequestModel request)
        {
            var createdMovie = await _movieRepository.AddAsync(new Movie {Title=request.Title,Budget=request.Budget,Revenue=request.Revenue });

            return new MovieDetailResponseModel {Id = createdMovie.Id,Title = createdMovie.Title,Budget=createdMovie.Budget,Revenue=request.Revenue };
        }

        public async Task<MovieDetailResponseModel> UpdateMovie(MovieCreateRequestModel request)
        {
            var updatedMovie = await _movieRepository.UpdateAsync(new Movie {Id = request.Id, Title = request.Title, Budget = request.Budget, Revenue = request.Revenue });
            return new MovieDetailResponseModel { Id = updatedMovie.Id, Title = updatedMovie.Title, Budget = updatedMovie.Budget, Revenue = updatedMovie.Revenue };
        }
    }
}

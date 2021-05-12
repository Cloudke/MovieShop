using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using ApplicationCore.Entities;
using ApplicationCore.Exceptions;

namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IReviewRepository _reviewRepository;
        public UserService(IUserRepository userRepository, IPurchaseRepository purchaseRepository, IReviewRepository reviewRepository)
        {
            _userRepository = userRepository;
            _purchaseRepository = purchaseRepository;
            _reviewRepository = reviewRepository;
        }
        public async Task<UserRegisterResponseModel> RegisterUser(UserRegisterRequestModel registerRequest)
        {
            //first check if user registered
            var dbuser = await _userRepository.GetUserByEmail(registerRequest.Email);
            if(dbuser != null)
            {
                throw new ConflictException("User Already exists,please try to login");
            }

            //generate a unique salt
            var salt = CreateSalt();

            //hash the password with salt

            var hashedPassword = CreateHashedPassword(registerRequest.Password, salt);

            // then create User Object and save it to database with UserRepository 

            var user = new User()
            {
                FirstName = registerRequest.FirstName,
                LastName = registerRequest.LastName,
                Email = registerRequest.Email,
                Salt = salt,
                HashedPassword = hashedPassword,
                DateOfBirth = registerRequest.DateTime,
            };

            // call repository to save User info that included salt and hashed password
            var createdUser = await _userRepository.AddAsync(user);

            // map user object to UserRegisterResponseModel object
            var createdUserResponse = new UserRegisterResponseModel
            {
                Id = createdUser.Id,
                Email = createdUser.Email,
                FirstName = createdUser.FirstName,
                LastName = createdUser.LastName
            };

            return createdUserResponse;
        }

        public async Task<LoginResponseModel> ValidateUser(string email, string password)
        {
            var dbUser = await _userRepository.GetUserByEmail(email);
            if(dbUser == null)
            {
                return null;
            }
            var hashedPassword = CreateHashedPassword(password, dbUser.Salt);
            if(hashedPassword == dbUser.HashedPassword)
            {
                var loginResponseModel = new LoginResponseModel { Id = dbUser.Id, Email = dbUser.Email, FirstName = dbUser.FirstName, LastName = dbUser.LastName };
                return loginResponseModel;
            }
            return null;
        }
        
        private string CreateSalt()
        {
            byte[] randomBytes = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }

            return Convert.ToBase64String(randomBytes);
        }

        private string CreateHashedPassword(string password, string salt)
        {
            var hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: Convert.FromBase64String(salt),
                prf: KeyDerivationPrf.HMACSHA512,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
            return hashed;
        }

        public async Task<UserRegisterResponseModel> GetUserProfile(string email)
        {
            var dbuser = await _userRepository.GetUserByEmail(email);
            if (dbuser == null)
            {
                return null;
            }
            var user = new UserRegisterResponseModel {Id = dbuser.Id,Email=dbuser.Email, FirstName=dbuser.FirstName,LastName=dbuser.LastName };
            return user;
        }

        public async Task<UserRequestModel> UpdateUser(UserRequestModel updateRequest)
        {
            var dbUser = await _userRepository.GetUserByEmail(updateRequest.Email);
            var getUser = new User { Id = dbUser.Id,Salt = dbUser.Salt,HashedPassword= CreateHashedPassword(updateRequest.Password, dbUser.Salt), Email = updateRequest.Email, FirstName = updateRequest.FirstName, LastName = updateRequest.LastName };
            var user = await _userRepository.UpdateAsync(getUser);
            var updatedUser = new UserRequestModel { Id = user.Id, Email = user.Email, FirstName = user.FirstName, LastName = user.LastName };
            return updatedUser;
        }

        public async Task<UserDetailsResponseModel> GetUserById(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                throw new NotFoundException("user does not exist");
            }

            var userDetails = new UserDetailsResponseModel
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName
            };

            return userDetails;
        }

        public async Task<IEnumerable<UserDetailsResponseModel>> GetAllUsers()
        {
            var users = await _userRepository.GetTop30Users();
            if (users == null)
            {
                throw new NotFoundException("user does not exist");
            }

            var allUsers = new List<UserDetailsResponseModel>();
            foreach (var user in users)
            {
                allUsers.Add(new UserDetailsResponseModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName
                });
            }
            return allUsers;

        }
        public async Task<IEnumerable<MovieCardResponseModel>> GetAllPurchasesById(int id)
        {
            var movies = await _purchaseRepository.GetAllPurchasesById(id);
            if (movies == null)
            {
                throw new NotFoundException("No purchased movies");
            }
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

        public async Task<IEnumerable<MovieCardResponseModel>> GetAllFavorite(int id)
        {
            var favorites = await _userRepository.GetAllFavoriteMovies(id);
            if (favorites == null)
            {
                throw new NotFoundException("No Favorite movies exist");
            }

            var allMovies = new List<MovieCardResponseModel>();
            foreach (var movie in favorites)
            {
                allMovies.Add(new MovieCardResponseModel
                {
                    Id = movie.MovieId,
                    Budget = movie.Movie.Budget,
                    Title = movie.Movie.Title,
                    PosterUrl = movie.Movie.PosterUrl,
                    Rating = movie.Movie.Rating
                });
            }
            return allMovies;
        }

        public async Task<IEnumerable<ReviewResponseModel>> GetAllReviewsById(int id)
        {
            var reviews = await _reviewRepository.GetAllReviewsByUser(id);
            var allReviews = new List<ReviewResponseModel>();
            foreach (var review in reviews)
            {
                allReviews.Add(new ReviewResponseModel
                {
                    UserId = review.UserId,
                    MovieId = review.MovieId,
                    FirstName = review.User.FirstName,
                    LastName = review.User.LastName,
                    Title = review.Movie.Title, 
                    PosterUrl = review.Movie.PosterUrl,
                    Rating = review.Rating,
                    ReviewText = review.ReviewText
                });
            }
            return allReviews;
        }
    }
}

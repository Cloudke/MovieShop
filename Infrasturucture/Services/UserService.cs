﻿using ApplicationCore.Models.Request;
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

namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<UserRegisterResponseModel> RegisterUser(UserRegisterRequestModel registerRequest)
        {
            //first check if user registered
            var dbuser = await _userRepository.GetUserByEmail(registerRequest.Email);
            if(dbuser != null)
            {
                throw new Exception("User Already exist");
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
    }
}

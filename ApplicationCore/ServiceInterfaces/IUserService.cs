﻿using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IUserService
    {
        Task<UserRegisterResponseModel> RegisterUser(UserRegisterRequestModel registerRequest);
        Task<LoginResponseModel> ValidateUser(string email, string password);
        Task<UserRegisterResponseModel> GetUserProfile(int id);

    }
}

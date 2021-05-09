using ApplicationCore.Models.Request;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MovieShop.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly ICurrentUserService _currentUserService;
        public AccountController(IUserService userService, ICurrentUserService currentUserService)
        {
            _userService = userService;
            _currentUserService = currentUserService;
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterRequestModel userRegisterRequestModel)
        {
            var newUser = await _userService.RegisterUser(userRegisterRequestModel);
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginRequestModel userLoginRequestModel)
        {
            var user = await _userService.ValidateUser(userLoginRequestModel.Email, userLoginRequestModel.Password);
            if(user == null)
            {
                return View();
            }
            //if user entered correct un/pw
            //Cookie based Auth
            //Claims firstlastname.dob.can be encrypted
            //key value
            var claims = new List<Claim>() { 
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Surname,user.LastName),
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.GivenName,user.FirstName)
            };

            //authentication type :cookie
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            //sign in and create cookie
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity));

            //return View();
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }

        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditProfile()
        {
            //Call the db and get the user info and fill that in textboxes so that user can edit
            var User = await _userService.GetUserProfile((int)_currentUserService.UserId);
            return View(User);
        }
        [HttpPut]
        public async Task<IActionResult> EditProfile(UserRequestModel userRequestModel)
        {
            // call the user service and map the UserRequestModel data in to User entity and call the repository
            return View();
        }
    }
}

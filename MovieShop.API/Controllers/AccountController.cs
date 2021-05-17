using ApplicationCore.Models.Request;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using ApplicationCore.Models.Response;

namespace MovieShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        public AccountController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpGet]
        [Route("{id:int}", Name = "GetUser")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);
            return Ok(user);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Register(UserRegisterRequestModel model)
        {
            var user = await _userService.RegisterUser(model);
            //201
            return CreatedAtRoute("GetUser",new { id = user.Id },user);
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllUsers()
        {
            //getlatest30users
            var user = await _userService.GetAllUsers();
            return Ok(user);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(UserLoginRequestModel user)
        {
            var dbuser = await _userService.ValidateUser(user.Email,user.Password);
            if(dbuser == null)
            {
                return Unauthorized();
            }
            var JwtToken = GenerateJWT(dbuser);
            // if user entered valid un/pw
            // create JWT Token

            return Ok(new { token = JwtToken });
        }

        private string GenerateJWT(LoginResponseModel model)
        {
            // we will use the token libraries to create token

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, model.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, model.Email),
                new Claim(JwtRegisteredClaimNames.GivenName, model.FirstName),
                new Claim(JwtRegisteredClaimNames.FamilyName, model.LastName)
            };

            // create identity object and store claims 
            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            // read the secret key from app settings, make sure secret key is unique and not guessable
            // In real world we use something like Azure KeyVault to store any secrets of application

            var secretKey = _configuration["JwtSettings:SecretKey"];
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            // get the expiration time of the token
            var expires = DateTime.UtcNow.AddDays(_configuration.GetValue<int>("JwtSettings:Expiration"));

            //pick an hashing algorithm 
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);


            // create the token object that yu will use to create the token that will include all the information such as credentials, claims, expiration time, 

            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = identityClaims,
                Expires = expires,
                SigningCredentials = credentials,
                Issuer = _configuration["JwtSettings:Issuer"],
                Audience = _configuration["JwtSettings:Audience"]
            };

            var encodedJwt = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(encodedJwt);
        }
    }
}

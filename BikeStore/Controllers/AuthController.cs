using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using BikeStore.Model.Dto;
using BikeStore.Model.Request;
using BikeStore.Model.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BikeStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public AuthController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetCurrentUser()
        {
            var requuser = HttpContext.User;

            AppUser user = new AppUser
            {
                UserName = requuser.Claims.First(claim => claim.Type == ClaimTypes.Email).Value,
                Email = requuser.Claims.First(claim => claim.Type == ClaimTypes.Email).Value,
                DisplayName = "Shubham Jain"
            };
            AuthResponse oResponse = new AuthResponse
            {
                username = user.UserName,
                displayName = user.DisplayName,
                token = GetToken(user)
            };

            return Ok(oResponse);
        }

        [HttpPost("Login")]
        public IActionResult Login(UserRequestModel userRequestModel)
        {
            IActionResult acResult = Forbid();
            if (userRequestModel.Username == "shubham" && userRequestModel.Password == "shubham")
            {
                AppUser user = new AppUser
                {
                    UserName = userRequestModel.Username,
                    Email = userRequestModel.Username,
                    DisplayName = "Shubham Jain"
                };

                AuthResponse oResponse = new AuthResponse
                {
                    username = user.UserName,
                    displayName = user.DisplayName,
                    token = GetToken(user)
                };
                acResult = Ok(oResponse);
            }        
            return acResult;
        }

        private string GetToken(AppUser user)
        {
            var claimsData = new[] 
            { 
                new Claim (ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, "Admin")
            };

            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signinCred = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                issuer : "BikeStore.com",
                audience : "BikeStore.com",
                expires : DateTime.Now.AddDays(7),
                claims : claimsData,
                signingCredentials: signinCred
                );

            var tokenString = new JwtSecurityTokenHandler()
                .WriteToken(token);

            return tokenString;
        }

        [HttpPost("Validate")] // In case you want to do the validation of JWt token explicitly
        public bool ValidateToken([FromQuery]string authToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = GetValidationParameters();

            SecurityToken validatedToken;
            try
            {
                IPrincipal principal = tokenHandler.ValidateToken(authToken, validationParameters, out validatedToken);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private TokenValidationParameters GetValidationParameters()
        {
            return new TokenValidationParameters()
            {
                ValidateLifetime = false, // Because there is no expiration in the generated token
                ValidateAudience = false, // Because there is no audiance in the generated token
                ValidateIssuer = false,   // Because there is no issuer in the generated token
                ValidIssuer = "Sample",
                ValidAudience = "Sample",
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])) // The same key as the one that generate the token
            };
        }

        public string GetClaim(string token, string claimType)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

            var stringClaimValue = securityToken.Claims.First(claim => claim.Type == claimType).Value;
            return stringClaimValue;
        }

    }
}
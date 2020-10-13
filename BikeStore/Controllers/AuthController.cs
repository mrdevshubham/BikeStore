using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BikeStore.Model.Request;
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

        [HttpPost("Login")]
        public IActionResult Login(UserRequestModel userRequestModel)
        {
            IActionResult acResult = Forbid();
            if (userRequestModel.Username == "shubham" && userRequestModel.Password == "shubham")
                acResult = Ok(GetToken());
            return acResult;
        }

        private string GetToken()
        {
            var claimsData = new[] 
            { 
                new Claim (ClaimTypes.Name, "username"),
                new Claim(ClaimTypes.Role, "Admin1")
            };

            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signinCred = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                issuer : "BikeStore.com",
                audience : "BikeStore.com",
                expires : DateTime.Now.AddMinutes(2),
                claims : claimsData,
                signingCredentials: signinCred
                );

            var tokenString = new JwtSecurityTokenHandler()
                .WriteToken(token);

            return tokenString;
        }

    }
}
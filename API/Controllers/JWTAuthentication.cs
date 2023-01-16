using API.DTO;
using API.Entities;
using Microsoft.AspNetCore.Authorization;    
using Microsoft.AspNetCore.Mvc;    
using Microsoft.Extensions.Configuration;    
using Microsoft.IdentityModel.Tokens;    
using System;    
using System.IdentityModel.Tokens.Jwt;    
using System.Security.Claims;    
using System.Text;    
    
namespace JWTAuthentication.Controllers    
{    
    [Route("api/[controller]")]    
    [ApiController]    
    public class LoginController : Controller    
    {    
        private IConfiguration _config;    
    
        public LoginController(IConfiguration config)    
        {    
            _config = config;    
        }

        [AllowAnonymous]    
        [HttpPost]    
        public IActionResult Login([FromBody]LoginDTO login)    
        {    
            IActionResult response = Unauthorized();    
            var user = AuthenticateUser(login);    
    
            if (user != null)    
            {    
                var tokenString = GenerateJSONWebToken(user);    
                //print 
                Console.WriteLine(tokenString);
                response = Ok(new { token = tokenString });    
            }    
    
            return response;    
        }

        private string GenerateJSONWebToken(LoginDTO userInfo)    
        {    
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));    
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);    
    
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],    
              _config["Jwt:Issuer"],    
              null,    
              expires: DateTime.Now.AddMinutes(120),    
              signingCredentials: credentials);    
    
            return new JwtSecurityTokenHandler().WriteToken(token);    
        }    
    
        private LoginDTO AuthenticateUser(LoginDTO login)    
        {    
            LoginDTO user = null;    
    
            //Validate the User Credentials    
            //Demo Purpose, I have Passed HardCoded User Information    
            if (login.userName == "guestUser")    
            {    
                user = new LoginDTO { userName = "guestUser", passwordHash = "test" };    
            }
    
            return user;    
        }    
    }    
}   
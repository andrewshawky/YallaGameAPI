using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using YallaGameAPISecure.Data;
using YallaGameAPISecure.Dtos;
using YallaGameAPISecure.Models;

namespace YallaGameAPISecure.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class AuthController :ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly IConfiguration config;

        public AuthController(IAuthRepository repo, IConfiguration config)
        {
            _repo = repo;
            this.config = config;
        }
        /// <summary>
        /// any additional info in register we can add it in this method
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody]UserForRegisterDtos dtos )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            //validate request here
            dtos.UserName = dtos.UserName.ToLower();//make all names in same case
             //make sure this name isn't taken
             if(await _repo.UserExists(dtos.UserName))
            {
                return BadRequest("user name is already exists");
            }
            //make sure this name isn't taken
            if (await _repo.EmailExists(dtos.Email))
            {
                return BadRequest("Email is already exists");
            }
            //create a user 
            var usertocreate = new User
            {
                Name = dtos.UserName,
            };
             var createduser = await _repo.Register(usertocreate, dtos.Password);
            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]UserForLoginDto userForLoginDto)
        {
            var userFromRepo = await _repo.Login(userForLoginDto.Username.ToLower(), userForLoginDto.Password);

            if (userFromRepo == null)
                return Unauthorized();

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,userFromRepo.UserId.ToString()),
                new Claim(ClaimTypes.Name,userFromRepo.Name)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new
            {
                token = tokenHandler.WriteToken(token)
            });
        }

    }
}
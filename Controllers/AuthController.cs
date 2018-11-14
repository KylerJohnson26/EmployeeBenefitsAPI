using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BenefitsManagementAPI.DTOs;
using BenefitsManagementAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using BenefitsManagementAPI.Helpers;
using BenefitsManagementAPI.DataModels;

namespace BenefitsManagementAPI.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepo;
        private readonly ISettingsHelper _settings;
        public AuthController(IAuthRepository authRepo, ISettingsHelper settingsHelper)
        {
            _authRepo = authRepo;
            _settings = settingsHelper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]UserForRegisterDto userForRegisterDto)
        {
            if(!string.IsNullOrEmpty(userForRegisterDto.Username))
                userForRegisterDto.Username = userForRegisterDto.Username.ToLower();

            if(await _authRepo.UserExists(userForRegisterDto.Username))
                ModelState.AddModelError("Username", "Username already exists");

            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var userToCreate = new User
            {
                Username = userForRegisterDto.Username,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                DateOfBirth = userForRegisterDto.DateOfBirth,
                Title = userForRegisterDto.Title,
                Created = DateTime.Now
            };

            var createdUser = await _authRepo.Register(userToCreate, userForRegisterDto.Password);
            return StatusCode(201); // todo: change this to CreatedAtRoute() method
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]UserForLoginDto userForLoginDto)
        {
            var userFromRepo = await _authRepo.Login(userForLoginDto.Username.ToLower(), userForLoginDto.Password);

            if(userFromRepo == null)
                return Unauthorized();
            
            // generate token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_settings.GetAuthKey());
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                  new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                  new Claim(ClaimTypes.Name, userFromRepo.Username)
                }),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            
            return Ok(new {tokenString});
        }  

    }
}
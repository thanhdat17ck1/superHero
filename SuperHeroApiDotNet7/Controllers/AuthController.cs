using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SuperHeroApiDotNet7.Repository;
using SuperHeroApiDotNet7.Services.UserService;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SuperHeroApiDotNet7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static User user = new User();
        private readonly IConfiguration _configuration;
        //private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;
        public AuthController(IConfiguration configuration, IUserRepository userRepository)
        {
            _configuration = configuration;
            _userRepository = userRepository;
        }

        //[HttpPost("register")]
        //public ActionResult<User> Register(UserDto request)
        //{
        //    string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
        //    user.UserName = request.UserName;
        //    user.PasswordHash = passwordHash;
        //    _userService.Register(user);
        //    return Ok(user);
        //}

        [HttpPost("register")]
        public async Task<ActionResult<List<User>>> Register(UserDto request)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
            user.UserName = request.UserName;
            user.PasswordHash = passwordHash;
            var result = await _userRepository.Register(user);
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<User>> Login(UserDto request)
        {
            var _pw = await _userRepository.GetUserByUsername(request.UserName);
            if (_pw == null)
            {
                return BadRequest("User not found");
            }
            if (!BCrypt.Net.BCrypt.Verify(request.Password, _pw.Trim()))
            {
                return BadRequest("wrong password.");
            }
            string token = CreateToken(user);
            return Ok(token);
        }
        //[HttpPost("login")]
        //public ActionResult<User> Login(UserDto request)
        //{
        //    if (user.UserName != request.UserName)
        //    {
        //        return BadRequest("User not found");
        //    }
        //    if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
        //    {
        //        return BadRequest("wrong password.");
        //    }
        //    string token = CreateToken(user);
        //    return Ok(token);
        //}
        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, "Admin"),
                new Claim(ClaimTypes.Role, "User"),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds
                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}

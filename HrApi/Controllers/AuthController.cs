using HrApi.Dto;
using HrApi.Models;
using HrApi.Models.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace HrApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly JwtOptions _jwtOptions;

        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager, IOptions<JwtOptions> jwtOptions)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtOptions = jwtOptions.Value;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> SignIn([FromBody] LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null)
            {
                return Unauthorized(new { Message = "Invalid credentials" });
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if (!result.Succeeded)
            {
                return Unauthorized(new { Message = "Invalid credentials" });
            }

            var token = await GenerateToken(user);

            return Ok(new { AccessToken = token });
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var user = new User
            {
                UserName = registerDto.Username,
                Email = registerDto.Email,
                PhoneNumber = registerDto.Phone,
                Avatar = "95f0922f-b810-4000-ae80-24840de12357.jpg"
            };
            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            await _userManager.AddToRoleAsync(user, Enum.GetName(Roles.Hr));


            return Ok(new { Message = "Registration successful" });
        }

        private async Task<string> GenerateToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Key));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var roles = await _userManager.GetRolesAsync(user);

            var claims = new List<Claim>
            {
                new (JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new (JwtRegisteredClaimNames.Email, user.Email is null ? string.Empty : user.Email),
                new (JwtRegisteredClaimNames.Name, user.UserName is null ? string.Empty : user.UserName),
                new (JwtRegisteredClaimNames.PhoneNumber, user.PhoneNumber is null ? string.Empty : user.PhoneNumber),
                new ("roles", string.Join(",", roles)),
                new ("avatar", user.Avatar)
            };

            var descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(60),
                SigningCredentials = credentials,
                Issuer = _jwtOptions.Issuer,
                Audience = _jwtOptions.Audience
            };

            var tokenHandler = new JsonWebTokenHandler();
            var token = tokenHandler.CreateToken(descriptor);

            return token;
        }
    }
}

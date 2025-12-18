using HrApi.Models;
using HrApi.Models.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HrApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly HrContext _context;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, HrContext context)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _context = context;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UploadAvatar(IFormFile file)
        {
            if (file.Length == 0 || file == null)
            {
                return BadRequest(new { Message = "No file provided" });
            }

            if (file.ContentType != "image/jpeg" && file.ContentType != "image/png")
            {
                return BadRequest(new { Message = "No image provided" });
            }
            var uploadDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/avatars");
            var extension = Path.GetExtension(file.FileName);
            var fileName = Guid.NewGuid().ToString() + extension;
            var filePath = Path.Combine(uploadDirectory, fileName);

            using var fs = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(fs);

            return Ok(new { Message = "File uploaded", ImageUrl = $"/images/avatars/{fileName}" });
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Info()
        {
            var message = new List<string>();
            foreach (var claim in User.Claims)
            {
                message.Add(claim.Value);
            }

            return Ok(new { Message = message });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user is null)
            {
                return BadRequest(new { Message = "User doesn't exist" });
            }

            var role = await _userManager.GetRolesAsync(user);
            if (role is null)
            {
                return BadRequest(new { Message = "Role doesn't exist" });
            }

            return Ok(new
            {
                user.Id,
                user.UserName,
                user.Email,
                user.Avatar,
                user.PhoneNumber,
                Role = role.FirstOrDefault()
            });
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Get(int count, int offset)
        {
            var users = await _context.Users
                .OrderBy(x => x.Id)
                .Skip(offset)
                .Take(count)
                .LeftJoin(_context.UserRoles, a => a.Id, b => b.UserId, (a, b) => new
                {
                    a.Id,
                    a.UserName,
                    a.Email,
                    a.Avatar,
                    a.PhoneNumber,
                    b.RoleId
                }).LeftJoin(_context.Roles, a => a.RoleId, b => b.Id, (a, b) => new
                {
                    a.Id,
                    a.UserName,
                    a.Email,
                    a.Avatar,
                    a.PhoneNumber,
                    b.Name
                }).ToListAsync();

            return Ok(users);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("[action]")]
        public async Task<IActionResult> ChangeRole(Guid userId, Roles role)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user is null)
            {
                return BadRequest(new { Message = "User doesn't exist" });
            }

            var newRole = Enum.GetName(role);
            if (newRole is null)
            {
                return BadRequest(new { Message = "Role doesn't exist" });
            }

            var result = await _userManager.AddToRoleAsync(user, newRole);
            if (!result.Succeeded)
            {
                return BadRequest(new { Message = "Can't change role" });
            }

            return Ok($"{user.UserName} is now {newRole}");
        }


        [HttpGet("[action]")]
        public new async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();

            return Ok(new { Message = "Signed out" });
        }

    }
}
using HrApi.Models;
using HrApi.Models.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HrApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
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

        [Authorize(Roles = "Admin")]
        [HttpPost("[action]")]
        public async Task<IActionResult> ChangeRole(string userId, Roles role)
        {
            var user = await _userManager.FindByIdAsync(userId);
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
        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();

            return Ok(new { Message = "Signed out" });
        }

    }
}
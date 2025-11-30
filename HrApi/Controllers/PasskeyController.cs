using HrApi.Models;
using HrApi.Models.Passkey;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace HrApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PasskeyController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public PasskeyController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public record OptionsDto(string Phone, string Email, string Username);

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateRegistrationOptions([FromBody] OptionsDto optionsDto)
        {
            var user = string.IsNullOrEmpty(optionsDto.Email) ? null : await _userManager.FindByEmailAsync(optionsDto.Email);

            if (user == null)
            {
                var result = await _userManager.CreateAsync(new User
                {
                    UserName = optionsDto.Username,
                    Email = optionsDto.Email,
                    PhoneNumber = optionsDto.Phone,
                });
            }

            var options = await _signInManager.MakePasskeyCreationOptionsAsync(
                new PasskeyUserEntity
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = optionsDto.Email,
                    DisplayName = optionsDto.Username
                }
            );

            return Ok(options);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CompleteRegistration([FromBody] PasskeyResult passkeyResult)
        {
            var optionsJson = JsonSerializer.Serialize(passkeyResult);
            var attestationResult = await _signInManager.PerformPasskeyAttestationAsync(optionsJson);

            if (!attestationResult.Succeeded)
            {
                return BadRequest($"Error: {attestationResult.Failure.Message}");
            }

            var user = await _userManager.FindByEmailAsync("mymail@mail.com");
            var addResult = await _userManager.AddOrUpdatePasskeyAsync(user, attestationResult.Passkey);

            if (!addResult.Succeeded)
            {
                return BadRequest("Failed to store passkey");
            }

            return Ok("Successful passkey registration");
        }
        //result = await navigator.credentials.create({publicKey: PublicKeyCredential.parseCreationOptionsFromJSON(json) })
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateAuthenticationOptions()
        {
            return Ok(new { a = "22" });
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CompleteAuthentication()
        {
            return Ok(new { a = "22" });
        }
    }
}
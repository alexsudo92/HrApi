using HrApi.Dto;
using HrApi.Models;
using HrApi.Models.Enums;
using HrApi.Models.Passkey;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace HrApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [AllowAnonymous]
    public class PasskeyController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;

        public PasskeyController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole<Guid>> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateRegistrationOptions([FromBody] RegistrationOptionsDto optionsDto)
        {
            var user = string.IsNullOrEmpty(optionsDto.Email) ? null : await _userManager.FindByEmailAsync(optionsDto.Email);
            var id = user == null ? Guid.NewGuid() : user.Id;
            if (user == null)
            {
                user = new User
                {
                    Id = id,
                    UserName = optionsDto.Username,
                    Email = optionsDto.Email,
                    PhoneNumber = optionsDto.Phone
                };

                var result = await _userManager.CreateAsync(user);

                if (!result.Succeeded)
                {
                    return BadRequest(result.Errors);
                }
            }
            await _userManager.AddToRoleAsync(user, Enum.GetName(Roles.Hr));

            var options = await _signInManager.MakePasskeyCreationOptionsAsync(
                new PasskeyUserEntity
                {
                    Id = id.ToString(),
                    Name = optionsDto.Email,
                    DisplayName = optionsDto.Username
                }
            );

            return Ok(options);
        }

        //result = await navigator.credentials.create({publicKey: PublicKeyCredential.parseCreationOptionsFromJSON(json) })
        [HttpPost("[action]")]
        public async Task<IActionResult> CompleteRegistration([FromBody] PasskeyDto<AttestationResponse> passkeyResultDto)
        {
            var optionsJson = JsonSerializer.Serialize(passkeyResultDto.Result);
            var attestationResult = await _signInManager.PerformPasskeyAttestationAsync(optionsJson);

            if (!attestationResult.Succeeded)
            {
                return BadRequest(attestationResult.Failure.Message);
            }

            var user = await _userManager.FindByEmailAsync(passkeyResultDto.Email);
            if (user == null)
            {
                return BadRequest(new { Message = "User doesn't exist" });
            }
            var addResult = await _userManager.AddOrUpdatePasskeyAsync(user, attestationResult.Passkey);

            if (!addResult.Succeeded)
            {
                return BadRequest(new { Message = "Failed to store passkey" });
            }

            return Ok(new { Message = "Successful passkey registration" });
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateAuthenticationOptions(string email)
        {
            ArgumentException.ThrowIfNullOrEmpty(email, nameof(email));

            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return BadRequest(new { Message = "User doesn't exist" });
            }

            var options = await _signInManager.MakePasskeyRequestOptionsAsync(user);

            return Ok(options);
        }

        //result = await navigator.credentials.get({publicKey: PublicKeyCredential.parseRequestOptionsFromJSON(json)})
        [HttpPost("[action]")]
        public async Task<IActionResult> CompleteAuthentication([FromBody] PasskeyDto<AssertionResponse> passkeyDto)
        {
            var json = JsonSerializer.Serialize(passkeyDto.Result);
            var assertionResult = await _signInManager.PerformPasskeyAssertionAsync(json);
            var result = await _signInManager.PasskeySignInAsync(json);

            if (result.Succeeded && assertionResult.Succeeded)
            {
                return Ok(new { Message = "Successful passkey authentication" });
            }
            else
            {
                return Unauthorized(new { Message = assertionResult.Failure?.Message ?? "Authentication failed" });
            }
        }
    }
}
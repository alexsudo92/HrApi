using HrApi.Models;
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

        public PasskeyController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateRegistrationOptions([FromBody] PasskeyOptionsDto optionsDto)
        {
            var user = string.IsNullOrEmpty(optionsDto.Email) ? null : await _userManager.FindByEmailAsync(optionsDto.Email);
            if (user == null)
            {
                user = new User
                {
                    UserName = optionsDto.Username,
                    Email = optionsDto.Email,
                    PhoneNumber = optionsDto.Phone,
                };

                var result = await _userManager.CreateAsync(user);

                if (!result.Succeeded)
                {
                    return BadRequest(result.Errors);
                }

                var options = await _signInManager.MakePasskeyCreationOptionsAsync(new PasskeyUserEntity
                {
                    Id = await _userManager.GetUserIdAsync(user),
                    Name = optionsDto.Email,
                    DisplayName = optionsDto.Username
                });

                return Ok(options);
            }
            else
            {
                var options = await _signInManager.MakePasskeyCreationOptionsAsync(
                    new PasskeyUserEntity
                    {
                        Id = user.Id.ToString(),
                        Name = optionsDto.Email,
                        DisplayName = optionsDto.Username
                    }
                );

                return Ok(options);
            }
        }

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

        //result = await navigator.credentials.create({publicKey: PublicKeyCredential.parseCreationOptionsFromJSON(json) })
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
                return Unauthorized(assertionResult.Failure.Message);
            }
        }
    }
}
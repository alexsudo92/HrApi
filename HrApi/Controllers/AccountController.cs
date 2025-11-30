using Microsoft.AspNetCore.Mvc;

namespace HrApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        [HttpPost("[action]")]
        public async Task<IActionResult> Register()
        {
            return Ok(new { message = "Register endpoint hit" });
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login()
        {
            return Ok(new { message = "Login endpoint hit" });
        }

    }
}
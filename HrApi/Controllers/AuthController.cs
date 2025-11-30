using Microsoft.AspNetCore.Mvc;

namespace HrApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpGet("open")]
        public IActionResult Open() => Ok("Open endpoint");
    }
}
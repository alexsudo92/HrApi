using Microsoft.AspNetCore.Mvc;

namespace HrApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CandidateController : ControllerBase
    {
        [HttpGet("open")]
        public IActionResult Open() => Ok("Open endpoint");
    }
}
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystemProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RateLimitController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { message = "Cox sayda get isteyi!!." });
        }
    }
}
    
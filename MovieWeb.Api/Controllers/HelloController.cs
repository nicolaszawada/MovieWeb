using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MovieWeb.Api.Dto;

namespace MovieWeb.Api.Controllers
{
    [Route("api/hello")]
    [ApiController]
    public class HelloController : ControllerBase
    {
        private readonly DeveloperDto _developer;
        private readonly ILogger<HelloController> _logger;

        public HelloController(IOptions<DeveloperDto> developerOptions,
            ILogger<HelloController> logger)
        {
            _developer = developerOptions.Value;
            _logger = logger;
        }

        [HttpGet("world")]
        public ActionResult<string> World([FromQuery] string name)
        {
            return "Hello World " + name;
        }

        [HttpGet("developer")]
        public ActionResult<DeveloperDto> Developer()
        {
            _logger.LogInformation("Hello from developer");
            return Ok(_developer);
        }
    }
}

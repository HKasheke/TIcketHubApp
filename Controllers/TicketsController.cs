using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TIcketHub.Models;

namespace TIcketHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ILogger<TicketsController> _logger;
        private readonly IConfiguration _configuration;

        public TicketsController(ILogger<TicketsController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello from Tickets Controller");
        }

        [HttpPost]
        public IActionResult Post(Purchase purchase)
        {
            if (string.IsNullOrEmpty(purchase.Name))
            {
                return BadRequest("Invalid name");
            }

            if (string.IsNullOrEmpty(purchase.Email))
            {
                return BadRequest("Invalid name");
            }

            return Ok("Hello from post" + purchase.Name + "Email: " + purchase.Email);
        }
    }
}

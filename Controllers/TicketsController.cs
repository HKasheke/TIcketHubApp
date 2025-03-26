using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
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
            if (!purchase.isValidEmail(purchase.Email))
            {
                return BadRequest("Invalid email");
            }

            if (!purchase.isValidName(purchase.Name))
            {
                return BadRequest("Invalid name");
            }

            if (!purchase.isValidPhoneNumber(purchase.Phone))
            {
                return BadRequest("Invalid Phone number");
            }

            if (!purchase.isValidCreditNum(purchase.CreditCard))
            {
                return BadRequest("Invalid Credit card");
            }


            if (!purchase.isValidCreditExp(purchase.Expiration))
            {
                return BadRequest("Invalid Expiry");
            }


            if (!purchase.isValidCreditSecCode(purchase.SecurityCode))
            {
                return BadRequest("Invalid Security Code");
            }


            if (string.IsNullOrEmpty(purchase.Address))
            {
                return BadRequest("Invalid Credit card");
            }

            return Ok("Hello from post " + purchase.Name + "Email: " + purchase.Email);
        }
    }
}
         
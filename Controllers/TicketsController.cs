using System.Text.Json;
using Azure.Storage.Queues;
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
        public async Task<IActionResult> Post(Purchase purchase)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            string queueName = "tickethub";

            // Get connection string from secrets.json
            string? connectionString = _configuration["AzureStorageConnectionString"];

            if (string.IsNullOrEmpty(connectionString))
            {
                return BadRequest("An error was encountered");
            }
            QueueClient queueClient = new QueueClient(connectionString, queueName);
            
            // serialize an object to json
            string message = JsonSerializer.Serialize(purchase);

            // send string message to queue
            await queueClient.SendMessageAsync(message);


            return Ok("Purchase successful for " + purchase.Name + ", Email: " + purchase.Email);
        }
    }
}
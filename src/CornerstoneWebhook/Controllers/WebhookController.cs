using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CornerstoneWebhook.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WebhookController : ControllerBase
    {
        private readonly ILogger<WebhookController> _logger;
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public WebhookController(ILogger<WebhookController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new System.Uri(configuration["CornerstoneApi:BaseUrl"]);
            _apiKey = configuration["CornerstoneApi:ApiKey"];
        }

        public async Task<HttpResponseMessage> PostAsync(string endpoint, object payload)
        {
            // Serialize payload to JSON
            var json = System.Text.Json.JsonSerializer.Serialize(payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Add API key header
            content.Headers.Add("X-Api-Key", _apiKey);

            // Send POST request
            return await _httpClient.PostAsync(endpoint, content);
        }
    }
}
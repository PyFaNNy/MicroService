using Microsoft.AspNetCore.Mvc;

namespace MicroService1.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();

            var result = await client.GetAsync("https://localhost:7002/home/index");

            var content = await result.Content.ReadAsStringAsync();
            return Ok(content);
        }
    }
}

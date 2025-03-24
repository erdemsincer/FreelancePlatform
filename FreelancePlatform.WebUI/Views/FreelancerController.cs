using FreelancePlatform.Core.DTOs.UserDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FreelancePlatform.WebUI.Controllers
{
    public class FreelancerController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FreelancerController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7085/api/User/freelancers"); // API URL’in doğru mu kontrol et
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var freelancers = JsonConvert.DeserializeObject<List<ResultUserDto>>(jsonData);
                return View(freelancers);
            }

            return View(new List<ResultUserDto>());
        }
    }
}

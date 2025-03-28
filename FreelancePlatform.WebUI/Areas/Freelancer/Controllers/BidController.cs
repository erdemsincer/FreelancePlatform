using FreelancePlatform.Core.DTOs.BidDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FreelancePlatform.WebUI.Areas.Freelancer.Controllers
{
    [Area("Freelancer")]
    public class BidController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BidController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> MyBids()
        {
            var userId = HttpContext.Session.GetInt32("userId");
            var token = HttpContext.Session.GetString("token");

            if (userId == null || string.IsNullOrEmpty(token))
                return RedirectToAction("Login", "Auth", new { area = "" });

            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var response = await client.GetAsync($"https://localhost:7085/api/Bid/freelancer/{userId}");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var bids = JsonConvert.DeserializeObject<List<ResultBidWithProjectDto>>(jsonData);
                return View(bids);
            }

            return View(new List<ResultBidWithProjectDto>());
        }
    }
}

using FreelancePlatform.Core.DTOs.BidDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http;

namespace FreelancePlatform.WebUI.Areas.Freelancer.Controllers
{
    [Area("Freelancer")]

    public class FreelancerBidController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FreelancerBidController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> MyBids()
        {
            var userId = HttpContext.Session.GetInt32("userId");
            var token = HttpContext.Session.GetString("token");

            if (userId == null || string.IsNullOrEmpty(token))
                return RedirectToAction("Login", "Auth");

            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await client.GetAsync($"https://localhost:7085/api/Bid/freelancer/{userId}");

            if (!response.IsSuccessStatusCode)
                return View(new List<ResultBidWithProjectDto>());

            var jsonData = await response.Content.ReadAsStringAsync();
            var bids = JsonConvert.DeserializeObject<List<ResultBidWithProjectDto>>(jsonData);

            return View(bids);
        }
    }
}

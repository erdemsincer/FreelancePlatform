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
            if (userId == null) return RedirectToAction("Login", "Auth");

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7085/api/Bid/freelancer/{userId}");

            if (!response.IsSuccessStatusCode) return View(new List<ResultBidDto>());

            var jsonData = await response.Content.ReadAsStringAsync();
            var bidList = JsonConvert.DeserializeObject<List<ResultBidDto>>(jsonData);

            return View(bidList);
        }
    }
}

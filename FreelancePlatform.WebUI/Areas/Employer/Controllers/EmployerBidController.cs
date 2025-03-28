using FreelancePlatform.Core.DTOs.BidDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FreelancePlatform.WebUI.Areas.Employer.Controllers
{
    [Area("Employer")]
    public class EmployerBidController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public EmployerBidController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> ProjectBids()
        {
            var employerId = HttpContext.Session.GetInt32("userId");
            var token = HttpContext.Session.GetString("token");

            if (employerId == null || string.IsNullOrEmpty(token))
                return RedirectToAction("Login", "Auth");

            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var response = await client.GetAsync($"https://localhost:7085/api/Bid/bids/employer/{employerId}");

            if (!response.IsSuccessStatusCode)
                return View(new List<ResultBidWithProjectDto>());

            var json = await response.Content.ReadAsStringAsync();
            var bids = JsonConvert.DeserializeObject<List<ResultBidWithProjectDto>>(json);

            return View(bids);
        }

        [HttpPost]
        public async Task<IActionResult> AcceptBid(int bidId)
        {
            var token = HttpContext.Session.GetString("token");
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var response = await client.PostAsync($"https://localhost:7085/api/Bid/accept/{bidId}", null);

            return RedirectToAction("ProjectBids");
        }
    }
}

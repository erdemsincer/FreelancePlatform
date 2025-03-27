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

        public async Task<IActionResult> ProjectBids(int projectId)
        {
            var employerId = HttpContext.Session.GetInt32("userId");
            var token = HttpContext.Session.GetString("token");

            if (employerId == null || string.IsNullOrEmpty(token))
            {
                TempData["error"] = "Lütfen giriş yapınız!";
                return RedirectToAction("Login", "Auth", new { area = "" });
            }

            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var response = await client.GetAsync($"https://localhost:7085/api/Bid/by-employer/{employerId}");
            if (!response.IsSuccessStatusCode)
            {
                TempData["error"] = "Teklifler alınamadı!";
                return View(new List<ResultBidWithProjectDto>());
            }

            var jsonData = await response.Content.ReadAsStringAsync();
            var bids = JsonConvert.DeserializeObject<List<ResultBidWithProjectDto>>(jsonData);

            return View(bids);
        }

        [HttpPost]
        public async Task<IActionResult> AcceptBid(int bidId, int projectId)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.PostAsync($"https://localhost:7085/api/Bid/accept/{bidId}", null);

            if (response.IsSuccessStatusCode)
                TempData["success"] = "Teklif kabul edildi.";
            else
                TempData["error"] = "Teklif kabul edilemedi.";

            return RedirectToAction("ProjectBids", new { projectId });
        }
    }
}

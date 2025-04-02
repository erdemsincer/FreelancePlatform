using FreelancePlatform.Core.DTOs.BidDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace FreelancePlatform.WebUI.Areas.Freelancer.Controllers
{
    [Area("Freelancer")]
    public class FreelancerProjectController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FreelancerProjectController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> AcceptedProjects()
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

            var json = await response.Content.ReadAsStringAsync();
            var allBids = JsonConvert.DeserializeObject<List<ResultBidWithProjectDto>>(json);

            var acceptedBids = allBids.Where(x => x.ProjectStatus == "Alındı").ToList();

            return View(acceptedBids);
        }
    }
}

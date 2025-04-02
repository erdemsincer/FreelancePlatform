using FreelancePlatform.Core.DTOs.ReviewDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace FreelancePlatform.WebUI.Areas.Employer.Controllers
{
    [Area("Employer")]
    public class ReviewController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ReviewController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Create(int projectId, int revieweeId)
        {
            var reviewerId = HttpContext.Session.GetInt32("userId") ?? 0;

            var model = new CreateReviewDto
            {
                ProjectId = projectId,
                ReviewerId = reviewerId,
                RevieweeId = revieweeId
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateReviewDto model)
        {
            var token = HttpContext.Session.GetString("token");
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://localhost:7085/api/Review", content);

            if (response.IsSuccessStatusCode)
            {
                TempData["success"] = "Değerlendirme başarıyla yapıldı!";
                return RedirectToAction("Index", "Dashboard", new { area = "Employer" });
            }

            TempData["error"] = "Değerlendirme gönderilemedi!";
            return View(model);
        }
    }
}

using FreelancePlatform.Core.DTOs.BidDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace FreelancePlatform.WebUI.Controllers
{
    public class BidController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BidController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Create(int projectId)
        {
            var token = HttpContext.Session.GetString("token");
            var userId = HttpContext.Session.GetInt32("userId");

            if (string.IsNullOrEmpty(token) || userId == null)
            {
                TempData["error"] = "Teklif verebilmek için giriş yapmalısınız!";
                return RedirectToAction("Login", "Auth");
            }

            var dto = new CreateBidDto
            {
                ProjectId = projectId,
                FreelancerId = userId.Value
            };

            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBidDto dto)
        {
            var token = HttpContext.Session.GetString("token");

            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var jsonData = JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://localhost:7085/api/Bid", content);

            if (response.IsSuccessStatusCode)
            {
                TempData["success"] = "Teklif başarıyla gönderildi!";
                return RedirectToAction("Detail", "Project", new { id = dto.ProjectId });
            }

            TempData["error"] = "Teklif gönderilirken hata oluştu!";
            return View(dto);
        }
    }
}

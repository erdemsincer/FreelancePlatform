using FreelancePlatform.Core.DTOs.ProjectDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FreelancePlatform.WebUI.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProjectController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7085/api/Project/detailed");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var projects = JsonConvert.DeserializeObject<List<ResultProjectDto>>(jsonData);
                return View(projects);
            }

            TempData["error"] = "Projeler yüklenemedi!";
            return View(new List<ResultProjectDto>());
        }

        // 🔹 Proje detayı
        public async Task<IActionResult> Detail(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7085/api/Project/{id}");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var project = JsonConvert.DeserializeObject<ResultProjectDto>(jsonData);
                return View(project);
            }

            TempData["error"] = "Proje bulunamadı!";
            return RedirectToAction("Index");
        }
    }
}

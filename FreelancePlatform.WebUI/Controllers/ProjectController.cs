using FreelancePlatform.Core.DTOs.CategoryDtos;
using FreelancePlatform.Core.DTOs.ProjectDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace FreelancePlatform.WebUI.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProjectController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // 🔹 Tüm projeleri listele (sadece "Açık" olanlar)
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();

            var response = await client.GetAsync("https://localhost:7085/api/Project/detailed");
            var categoryResponse = await client.GetAsync("https://localhost:7085/api/Category");

            if (!response.IsSuccessStatusCode || !categoryResponse.IsSuccessStatusCode)
            {
                TempData["error"] = "Projeler veya kategoriler yüklenemedi!";
                return View(new List<ResultProjectDto>());
            }

            var json = await response.Content.ReadAsStringAsync();
            var allProjects = JsonConvert.DeserializeObject<List<ResultProjectDto>>(json);

            // ✅ Sadece "Açık" olan projeleri filtrele
            var openProjects = allProjects.Where(p => p.Status == "Açık").ToList();

            var categoryJson = await categoryResponse.Content.ReadAsStringAsync();
            var categories = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(categoryJson);

            ViewBag.Categories = categories;

            return View(openProjects);
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

        public async Task<IActionResult> ProjectsByCategory(int categoryId)
        {
            var client = _httpClientFactory.CreateClient();

            HttpResponseMessage response;

            if (categoryId == 0)
            {
                // 0 ise tüm projeleri çek
                response = await client.GetAsync("https://localhost:7085/api/Project/detailed");
            }
            else
            {
                // Belirli kategoriye göre filtrele
                response = await client.GetAsync($"https://localhost:7085/api/Project/category/{categoryId}");
            }

            var categoryResponse = await client.GetAsync("https://localhost:7085/api/Category");

            if (!response.IsSuccessStatusCode || !categoryResponse.IsSuccessStatusCode)
                return View("Index", new List<ResultProjectDto>());

            var json = await response.Content.ReadAsStringAsync();
            var filteredProjects = JsonConvert.DeserializeObject<List<ResultProjectDto>>(json);

            // Sadece "Açık" olan projeler
            filteredProjects = filteredProjects.Where(p => p.Status == "Açık").ToList();

            var categoryJson = await categoryResponse.Content.ReadAsStringAsync();
            var categories = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(categoryJson);

            ViewBag.Categories = categories;

            return View("Index", filteredProjects);
        }

    }
}

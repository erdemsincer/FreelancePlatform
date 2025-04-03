using FreelancePlatform.Core.DTOs.CategoryDtos;
using FreelancePlatform.Core.DTOs.ProjectDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FreelancePlatform.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // Tüm kategorileri listele
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7085/api/Category");

            if (!response.IsSuccessStatusCode)
                return View(new List<ResultCategoryDto>());

            var json = await response.Content.ReadAsStringAsync();
            var categories = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(json);

            return View(categories);
        }

        // Bir kategoriye ait projeleri getir
        public async Task<IActionResult> ProjectsByCategory(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7085/api/Project/category/{id}");

            if (!response.IsSuccessStatusCode)
                return View(new List<ResultProjectDto>());

            var json = await response.Content.ReadAsStringAsync();
            var projects = JsonConvert.DeserializeObject<List<ResultProjectDto>>(json);

            var openProjects = projects.Where(p => p.Status == "Açık").ToList();

            return View(openProjects); // => @model List<ResultProjectDto>
        }

    }
}

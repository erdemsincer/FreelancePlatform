using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreelancePlatform.Core.DTOs.ProjectDtos;

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
            var response = await client.GetAsync("https://localhost:7085/api/Project"); // API adresinize göre düzenleyin

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var projectList = JsonConvert.DeserializeObject<List<ResultProjectDto>>(jsonData);
                return View(projectList);
            }

            return View(new List<ResultProjectDto>());
        }
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

            return RedirectToAction("Index");
        }

    }
}

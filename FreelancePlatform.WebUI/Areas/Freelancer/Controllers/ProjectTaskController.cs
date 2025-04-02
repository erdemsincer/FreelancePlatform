using FreelancePlatform.Core.DTOs.ProjectTaskDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace FreelancePlatform.WebUI.Areas.Freelancer.Controllers
{
    [Area("Freelancer")]
    public class ProjectTaskController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProjectTaskController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int projectId)
        {
            var token = HttpContext.Session.GetString("token");
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await client.GetAsync($"https://localhost:7085/api/ProjectTask/project/{projectId}");
            var tasks = new List<ResultProjectTaskDto>();

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                tasks = JsonConvert.DeserializeObject<List<ResultProjectTaskDto>>(json);
            }

            ViewBag.ProjectId = projectId;
            return View(tasks);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateStatus(int taskId, string newStatus, int projectId)
        {
            var token = HttpContext.Session.GetString("token");
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var updateData = new { Id = taskId, Status = newStatus };
            var jsonData = JsonConvert.SerializeObject(updateData);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await client.PutAsync("https://localhost:7085/api/ProjectTask", content);

            if (!response.IsSuccessStatusCode)
            {
                TempData["error"] = "Görev güncellenemedi!";
            }
            else
            {
                TempData["success"] = "Görev başarıyla güncellendi!";
            }

            return RedirectToAction("Index", new { projectId });
        }

        [HttpGet]
        public IActionResult Create(int projectId)
        {
            var model = new CreateProjectTaskDto
            {
                ProjectId = projectId
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProjectTaskDto dto)
        {
            var token = HttpContext.Session.GetString("token");
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://localhost:7085/api/ProjectTask", content);

            if (response.IsSuccessStatusCode)
            {
                TempData["success"] = "Görev başarıyla eklendi!";
                return RedirectToAction("Index", new { projectId = dto.ProjectId });
            }

            TempData["error"] = "Görev eklenirken hata oluştu!";
            return View(dto);
        }


    }
}

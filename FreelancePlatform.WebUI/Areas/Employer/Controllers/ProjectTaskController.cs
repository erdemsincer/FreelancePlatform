using FreelancePlatform.Core.DTOs.ProjectTaskDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace FreelancePlatform.WebUI.Areas.Employer.Controllers
{
    [Area("Employer")]
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
    }
}

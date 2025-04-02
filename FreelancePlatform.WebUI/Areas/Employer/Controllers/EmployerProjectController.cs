using FreelancePlatform.Core.DTOs.ProjectDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace FreelancePlatform.WebUI.Areas.Employer.Controllers
{
    [Area("Employer")]
    public class EmployerProjectController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public EmployerProjectController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> MyProjects()
        {
            var userId = HttpContext.Session.GetInt32("userId");
            var token = HttpContext.Session.GetString("token");

            if (userId == null || string.IsNullOrEmpty(token))
                return RedirectToAction("Login", "Auth");

            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await client.GetAsync($"https://localhost:7085/api/Project/employer/{userId}");

            if (!response.IsSuccessStatusCode)
                return View(new List<ResultProjectDto>());

            var json = await response.Content.ReadAsStringAsync();
            var projects = JsonConvert.DeserializeObject<List<ResultProjectDto>>(json);

            return View(projects);
        }
    }
}

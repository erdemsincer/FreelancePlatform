using FreelancePlatform.Core.DTOs.ProjectDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FreelancePlatform.WebUI.ViewComponents
{
    public class CompletedProjectsViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CompletedProjectsViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7085/api/Project/completed");

            if (!response.IsSuccessStatusCode)
                return View(new List<ResultProjectDto>());

            var json = await response.Content.ReadAsStringAsync();
            var projects = JsonConvert.DeserializeObject<List<ResultProjectDto>>(json);

            return View(projects);
        }
    }
}

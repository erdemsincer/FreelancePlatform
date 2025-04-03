using FreelancePlatform.Core.DTOs.ProjectDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FreelancePlatform.WebUI.ViewComponents
{
    public class PortfolioViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PortfolioViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int userId)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7085/api/Project/freelancer/completed/"+ userId);

            if (!response.IsSuccessStatusCode) return View(new List<ResultProjectDto>());

            var json = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<ResultProjectDto>>(json);

            return View(data);
        }
    }
}

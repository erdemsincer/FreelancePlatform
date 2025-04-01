using FreelancePlatform.Core.DTOs.CategoryDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FreelancePlatform.WebUI.ViewComponents
{
    public class CategoryListViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CategoryListViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7085/api/Category");

            if (!response.IsSuccessStatusCode)
                return View(new List<ResultCategoryDto>()); // boş liste döner

            var json = await response.Content.ReadAsStringAsync();
            var categories = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(json);
            return View(categories);
        }
    }
}

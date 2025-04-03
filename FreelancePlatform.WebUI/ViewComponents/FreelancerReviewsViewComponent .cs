using FreelancePlatform.Core.DTOs.ReviewDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FreelancePlatform.WebUI.ViewComponents
{
    public class FreelancerReviewsViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FreelancerReviewsViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int userId)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7085/api/Review/freelancer/{userId}");

            if (!response.IsSuccessStatusCode)
                return View(new List<ResultReviewDto>());

            var json = await response.Content.ReadAsStringAsync();
            var reviews = JsonConvert.DeserializeObject<List<ResultReviewDto>>(json);

            return View(reviews);
        }
    }
}

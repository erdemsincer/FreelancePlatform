using FreelancePlatform.Core.DTOs.AdvertisementDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FreelancePlatform.WebUI.ViewComponents
{
    public class UserAdvertisementsViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UserAdvertisementsViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int userId)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7085/api/Advertisement/freelancer/{userId}");

            if (!response.IsSuccessStatusCode)
                return View(new List<ResultAdvertisementDto>());

            var json = await response.Content.ReadAsStringAsync();
            var ads = JsonConvert.DeserializeObject<List<ResultAdvertisementDto>>(json);

            return View(ads);
        }
    }
}

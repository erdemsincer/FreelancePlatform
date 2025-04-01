using FreelancePlatform.Core.DTOs.AdvertisementDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FreelancePlatform.WebUI.ViewComponents
{
    public class AdvertisementViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdvertisementViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7085/api/Advertisement");

            if (!response.IsSuccessStatusCode)
                return View(new List<ResultAdvertisementDto>()); // boş liste gönder

            var json = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<ResultAdvertisementDto>>(json);

            return View(data);
        }
    }
}

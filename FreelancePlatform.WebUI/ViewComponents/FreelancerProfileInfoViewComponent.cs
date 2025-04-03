using FreelancePlatform.Core.DTOs.UserDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FreelancePlatform.WebUI.ViewComponents
{
    public class FreelancerProfileInfoViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FreelancerProfileInfoViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int freelancerId)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7085/api/User/public/{freelancerId}");

            if (!response.IsSuccessStatusCode)
                return View(null); // veya hata view'ı döndür

            var json = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<ResultUserDto>(json);

            return View(user);
        }
    }
}

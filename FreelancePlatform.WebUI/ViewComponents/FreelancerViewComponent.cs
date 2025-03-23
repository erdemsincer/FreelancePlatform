using FreelancePlatform.Core.DTOs.UserDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FreelancePlatform.WebUI.ViewComponents
{
    public class FreelancerViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FreelancerViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7085/api/User/freelancers");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var freelancers = JsonConvert.DeserializeObject<List<ResultUserDto>>(jsonData);
                return View(freelancers);
            }

            return View(new List<ResultUserDto>());
        }
    }
}

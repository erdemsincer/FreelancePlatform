using FreelancePlatform.Core.DTOs.UserDtos;
using Microsoft.AspNetCore.Mvc;

namespace FreelancePlatform.WebUI.Controllers
{
    public class UsersController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UsersController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task< IActionResult> Index(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var values=await client.GetFromJsonAsync<ResultUserDto>("https://localhost:7085/api/User/" + id);
            ViewBag.UserId = id;
            return View(values);
        }
    }
}

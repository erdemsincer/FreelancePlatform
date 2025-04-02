using FreelancePlatform.Core.DTOs.ReviewDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace FreelancePlatform.WebUI.Areas.Freelancer.Controllers
{
    
        [Area("Freelancer")]
        public class FreelancerReviewController : Controller
        {
            private readonly IHttpClientFactory _httpClientFactory;

            public FreelancerReviewController(IHttpClientFactory httpClientFactory)
            {
                _httpClientFactory = httpClientFactory;
            }

            public async Task<IActionResult> Index()
            {
                var userId = HttpContext.Session.GetInt32("userId");
                var token = HttpContext.Session.GetString("token");

                if (userId == null || string.IsNullOrEmpty(token))
                    return RedirectToAction("Login", "Auth");

                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var response = await client.GetAsync($"https://localhost:7085/api/Review/freelancer/{userId}");

                if (!response.IsSuccessStatusCode)
                    return View(new List<ResultReviewDto>());

                var json = await response.Content.ReadAsStringAsync();
                var reviews = JsonConvert.DeserializeObject<List<ResultReviewDto>>(json);

                return View(reviews);
            }
        }
    }


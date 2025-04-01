using FreelancePlatform.Core.DTOs.AuthDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace FreelancePlatform.WebUI.Controllers
{
    public class AuthController : Controller
    {
        private readonly HttpClient _httpClient;

        public AuthController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7085/api/"); // API adresin burası!
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestDto model)
        {
            var jsonData = JsonConvert.SerializeObject(model);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("Auth/Login", content);
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                var tokenObj = JsonConvert.DeserializeObject<TokenResponseDto>(responseBody);

                // Token ve userId
                HttpContext.Session.SetString("token", tokenObj.Token);

                var handler = new JwtSecurityTokenHandler();
                var token = handler.ReadJwtToken(tokenObj.Token);

                var userIdClaim = token.Claims.FirstOrDefault(c =>
                    c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");

                if (userIdClaim != null)
                {
                    HttpContext.Session.SetInt32("userId", int.Parse(userIdClaim.Value));
                }

                // 👇 Kullanıcı adını Session'a ekle
                if (!string.IsNullOrEmpty(tokenObj.Username))
                {
                    HttpContext.Session.SetString("userFullName", tokenObj.Username);
                }

                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Hatalı giriş bilgileri!";
            return View(model);
        }




        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequestDto model)
        {
            var jsonData = JsonConvert.SerializeObject(model);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("Auth/Register", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Login");
            }

            ViewBag.Error = "Kayıt başarısız!";
            return View(model);
        }
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Auth");
        }
    }
}

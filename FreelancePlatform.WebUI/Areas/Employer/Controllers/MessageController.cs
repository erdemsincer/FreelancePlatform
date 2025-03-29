using FreelancePlatform.Core.DTOs.MessageDtos;
using FreelancePlatform.WebUI.Areas.Employer.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace FreelancePlatform.WebUI.Areas.Employer.Controllers
{
    [Area("Employer")]
    public class MessageController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MessageController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> SendMessage(int receiverId)
        {
            var senderId = HttpContext.Session.GetInt32("userId");
            var token = HttpContext.Session.GetString("token");

            if (senderId == null || string.IsNullOrEmpty(token))
                return RedirectToAction("Login", "Auth", new { area = "" });

            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var messages = new List<ResultMessageDto>();

            // ✅ Doğru endpoint: path parametreli versiyon
            var response = await client.GetAsync($"https://localhost:7085/api/Message/conversation/{senderId}/{receiverId}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                messages = JsonConvert.DeserializeObject<List<ResultMessageDto>>(json);
            }

            var viewModel = new MessageChatViewModel
            {
                Messages = messages,
                NewMessage = new CreateMessageDto
                {
                    SenderId = senderId.Value,
                    ReceiverId = receiverId
                }
            };

            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> SendMessage(MessageChatViewModel viewModel)
        {
            var token = HttpContext.Session.GetString("token");

            if (string.IsNullOrEmpty(token))
            {
                TempData["error"] = "Yetkilendirme hatası!";
                return RedirectToAction("Login", "Auth", new { area = "" });
            }

            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var jsonData = JsonConvert.SerializeObject(viewModel.NewMessage);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://localhost:7085/api/Message", content);

            if (response.IsSuccessStatusCode)
            {
                TempData["success"] = "Mesaj başarıyla gönderildi!";
                return RedirectToAction("SendMessage", new { receiverId = viewModel.NewMessage.ReceiverId });
            }

            TempData["error"] = "Mesaj gönderilemedi!";
            return RedirectToAction("SendMessage", new { receiverId = viewModel.NewMessage.ReceiverId });
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}

using AutoMapper;
using FreelancePlatform.Core.DTOs.NotificationDtos;
using FreelancePlatform.Core.Entities;
using FreelancePlatform.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FreelancePlatform.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;

        public NotificationController(INotificationService notificationService, IMapper mapper)
        {
            _notificationService = notificationService;
            _mapper = mapper;
        }

        // ✅ Tüm bildirimleri getir
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var notifications = await _notificationService.TGetListAllAsync();
            var resultDtos = _mapper.Map<List<ResultNotificationDto>>(notifications);
            return Ok(resultDtos);
        }

        // ✅ Belirli bildirimi getir
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var notification = await _notificationService.TGetByIdAsync(id);
            if (notification == null) return NotFound("Bildirim bulunamadı!");
            var resultDto = _mapper.Map<ResultNotificationDto>(notification);
            return Ok(resultDto);
        }

        // ✅ Bildirim oluştur
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateNotificationDto dto)
        {
            var notification = _mapper.Map<Notification>(dto);
            notification.CreatedAt = DateTime.UtcNow;
            notification.IsRead = false;
            await _notificationService.TAddAsync(notification);
            return Ok(new { message = "Bildirim başarıyla oluşturuldu!" });
        }

        // ✅ Bildirimi okundu olarak işaretle
        [HttpPost("{id}/mark-as-read")]
        public async Task<IActionResult> MarkAsRead(int id)
        {
            var notification = await _notificationService.TGetByIdAsync(id);
            if (notification == null) return NotFound("Bildirim bulunamadı!");

            notification.IsRead = true;
            await _notificationService.TUpdateAsync(notification);
            return Ok(new { message = "Bildirim okundu olarak işaretlendi!" });
        }

        // ✅ Bildirim sil
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var notification = await _notificationService.TGetByIdAsync(id);
            if (notification == null) return NotFound("Bildirim bulunamadı!");

            await _notificationService.TDeleteAsync(notification);
            return Ok(new { message = "Bildirim başarıyla silindi!" });
        }
    }
}

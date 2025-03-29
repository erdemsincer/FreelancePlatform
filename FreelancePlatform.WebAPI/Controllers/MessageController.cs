using AutoMapper;
using FreelancePlatform.Core.DTOs.MessageDtos;
using FreelancePlatform.Core.Entities;
using FreelancePlatform.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FreelancePlatform.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly IMapper _mapper;

        public MessageController(IMessageService messageService, IMapper mapper)
        {
            _messageService = messageService;
            _mapper = mapper;
        }

        // ✅ Tüm mesajları getir
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var messages = await _messageService.TGetListAllAsync();
            var resultDtos = _mapper.Map<List<ResultMessageDto>>(messages);
            return Ok(resultDtos);
        }

        // ✅ Belirli mesajı getir
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var message = await _messageService.TGetByIdAsync(id);
            if (message == null) return NotFound("Mesaj bulunamadı!");
            var resultDto = _mapper.Map<ResultMessageDto>(message);
            return Ok(resultDto);
        }

       
    

        // ✅ Mesaj sil
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var message = await _messageService.TGetByIdAsync(id);
            if (message == null) return NotFound("Mesaj bulunamadı!");

            await _messageService.TDeleteAsync(message);
            return Ok(new { message = "Mesaj başarıyla silindi!" });
        }

        [HttpGet("conversation/{user1Id}/{user2Id}")]
        public async Task<IActionResult> GetConversation(int user1Id, int user2Id)
        {
            var messages = await _messageService.GetConversationAsync(user1Id, user2Id);
            var result = _mapper.Map<List<ResultMessageDto>>(messages);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> SendMessage([FromBody] CreateMessageDto dto)
        {
            var message = _mapper.Map<Message>(dto);
            message.SentAt = DateTime.UtcNow;
            await _messageService.TAddAsync(message);
            return Ok();
        }


    }
}

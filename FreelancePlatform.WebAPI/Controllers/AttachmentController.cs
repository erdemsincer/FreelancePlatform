using AutoMapper;
using FreelancePlatform.Core.DTOs.AttachmentDtos;
using FreelancePlatform.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Attachment = FreelancePlatform.Core.Entities.Attachment;

namespace FreelancePlatform.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttachmentController : ControllerBase
    {
        private readonly IAttachmentService _attachmentService;
        private readonly IMapper _mapper;

        public AttachmentController(IAttachmentService attachmentService, IMapper mapper)
        {
            _attachmentService = attachmentService;
            _mapper = mapper;
        }

        // ✅ Tüm dosya eklerini getir
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var attachments = await _attachmentService.TGetListAllAsync();
            var resultDtos = _mapper.Map<List<ResultAttachmentDto>>(attachments);
            return Ok(resultDtos);
        }

        // ✅ Belirli dosya ekini getir
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var attachment = await _attachmentService.TGetByIdAsync(id);
            if (attachment == null) return NotFound("Dosya eki bulunamadı!");
            var resultDto = _mapper.Map<ResultAttachmentDto>(attachment);
            return Ok(resultDto);
        }

        // ✅ Yeni dosya eki ekle
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAttachmentDto dto)
        {
            var attachment = _mapper.Map<Attachment>(dto);
            
            await _attachmentService.TAddAsync(attachment);
            return Ok(new { message = "Dosya eki başarıyla eklendi!" });
        }

        // ✅ Dosya ekini güncelle (Opsiyonel)
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateAttachmentDto dto)
        {
            var attachment = await _attachmentService.TGetByIdAsync(dto.Id);
            if (attachment == null) return NotFound("Dosya eki bulunamadı!");

            _mapper.Map(dto, attachment);
            await _attachmentService.TUpdateAsync(attachment);
            return Ok(new { message = "Dosya eki başarıyla güncellendi!" });
        }

        // ✅ Dosya ekini sil
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var attachment = await _attachmentService.TGetByIdAsync(id);
            if (attachment == null) return NotFound("Dosya eki bulunamadı!");

            await _attachmentService.TDeleteAsync(attachment);
            return Ok(new { message = "Dosya eki başarıyla silindi!" });
        }
    }
}

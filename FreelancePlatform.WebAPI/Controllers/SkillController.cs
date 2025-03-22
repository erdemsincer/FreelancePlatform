using AutoMapper;
using FreelancePlatform.Core.DTOs.SkillDtos;
using FreelancePlatform.Core.Entities;
using FreelancePlatform.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FreelancePlatform.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private readonly ISkillService _skillService;
        private readonly IMapper _mapper;

        public SkillController(ISkillService skillService, IMapper mapper)
        {
            _skillService = skillService;
            _mapper = mapper;
        }

        // ✅ Tüm skill'leri getir
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var skills = await _skillService.TGetListAllAsync();
            var resultDtos = _mapper.Map<List<ResultSkillDto>>(skills);
            return Ok(resultDtos);
        }

        // ✅ Belirli skill getir
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var skill = await _skillService.TGetByIdAsync(id);
            if (skill == null) return NotFound("Skill bulunamadı!");
            var resultDto = _mapper.Map<ResultSkillDto>(skill);
            return Ok(resultDto);
        }

        // ✅ Yeni skill ekle
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSkillDto dto)
        {
            var skill = _mapper.Map<Skill>(dto);
            await _skillService.TAddAsync(skill);
            return Ok(new { message = "Skill başarıyla eklendi!" });
        }

        // ✅ Skill sil
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var skill = await _skillService.TGetByIdAsync(id);
            if (skill == null) return NotFound("Skill bulunamadı!");

            await _skillService.TDeleteAsync(skill);
            return Ok(new { message = "Skill başarıyla silindi!" });
        }
    }
}

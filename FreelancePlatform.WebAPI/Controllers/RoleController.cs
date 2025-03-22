using AutoMapper;
using FreelancePlatform.Core.DTOs.RoleDtos;
using FreelancePlatform.Core.Entities;
using FreelancePlatform.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FreelancePlatform.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;

        public RoleController(IRoleService roleService, IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }

        // ✅ Tüm rolleri listele
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var roles = await _roleService.TGetListAllAsync();
            var resultDtos = _mapper.Map<List<ResultRoleDto>>(roles);
            return Ok(resultDtos);
        }

        // ✅ Rol detayını getir
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var role = await _roleService.TGetByIdAsync(id);
            if (role == null) return NotFound("Rol bulunamadı!");
            var resultDto = _mapper.Map<ResultRoleDto>(role);
            return Ok(resultDto);
        }

        // ✅ Yeni rol oluştur
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRoleDto dto)
        {
            var role = _mapper.Map<Role>(dto);
            await _roleService.TAddAsync(role);
            return Ok(new { message = "Rol başarıyla oluşturuldu!" });
        }

        // ✅ Rol güncelle
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ResultRoleDto dto)
        {
            var role = await _roleService.TGetByIdAsync(dto.Id);
            if (role == null) return NotFound("Rol bulunamadı!");

            role.Name = dto.Name;
            
            await _roleService.TUpdateAsync(role);
            return Ok(new { message = "Rol başarıyla güncellendi!" });
        }

        // ✅ Rol sil
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var role = await _roleService.TGetByIdAsync(id);
            if (role == null) return NotFound("Rol bulunamadı!");

            await _roleService.TDeleteAsync(role);
            return Ok(new { message = "Rol başarıyla silindi!" });
        }
    }
}

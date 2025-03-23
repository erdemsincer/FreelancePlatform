using AutoMapper;
using FreelancePlatform.Core.DTOs.UserDtos;
using FreelancePlatform.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FreelancePlatform.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        // ✅ Tüm kullanıcıları listele
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.TGetListAllAsync();
            var resultDtos = _mapper.Map<List<ResultUserDto>>(users);
            return Ok(resultDtos);
        }

        // ✅ Kullanıcı detayını getir
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.TGetByIdAsync(id);
            if (user == null) return NotFound("Kullanıcı bulunamadı!");
            var resultDto = _mapper.Map<ResultUserDto>(user);
            return Ok(resultDto);
        }

        // ✅ Kullanıcı bilgilerini güncelle
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserDto dto)
        {
            var user = await _userService.TGetByIdAsync(dto.Id);
            if (user == null) return NotFound("Kullanıcı bulunamadı!");

            _mapper.Map(dto, user);
            await _userService.TUpdateAsync(user);
            return Ok(new { message = "Kullanıcı bilgileri başarıyla güncellendi!" });
        }

        // ✅ Kullanıcıyı sil
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userService.TGetByIdAsync(id);
            if (user == null) return NotFound("Kullanıcı bulunamadı!");

            await _userService.TDeleteAsync(user);
            return Ok(new { message = "Kullanıcı başarıyla silindi!" });
        }
        [HttpGet("freelancers")]
        public async Task<IActionResult> GetFreelancers()
        {
            var freelancers = await _userService.GetFreelancerUsersAsync();
            return Ok(freelancers);
        }


    }
}

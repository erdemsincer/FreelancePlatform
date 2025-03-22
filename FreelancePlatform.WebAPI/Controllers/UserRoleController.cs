using AutoMapper;
using FreelancePlatform.Core.DTOs.UserRoleDtos;
using FreelancePlatform.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FreelancePlatform.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        private readonly IUserRoleService _userRoleService;
        private readonly IMapper _mapper;

        public UserRoleController(IUserRoleService userRoleService, IMapper mapper)
        {
            _userRoleService = userRoleService;
            _mapper = mapper;
        }

        // ✅ Tüm kullanıcı-rol ilişkilerini getir
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var userRoles = await _userRoleService.GetAllUserRolesAsync();
            var mappedUserRoles=_mapper.Map<List<ResultUserRoleDto>>(userRoles);
            return Ok(mappedUserRoles);
        }

        // ✅ Belirli kullanıcının rollerini getir
        [HttpGet("user/{userId}/roles")]
        public async Task<IActionResult> GetRolesByUserId(int userId)
        {
            var roles = await _userRoleService.GetRolesByUserId(userId);
            return Ok(roles.Select(r => r.Role.Name).ToList());
        }

        // ✅ Kullanıcıya rol ata
        [HttpPost("assign")]
        public async Task<IActionResult> AssignRole(int userId, int roleId)
        {
            await _userRoleService.AssignRoleAsync(userId, roleId);
            return Ok(new { message = "Rol kullanıcıya başarıyla atandı!" });
        }

        // ✅ (Opsiyonel) Kullanıcıdan rol kaldır
        [HttpPost("remove")]
        public async Task<IActionResult> RemoveRole(int userId, int roleId)
        {
            var userRoles = await _userRoleService.TGetListAllAsync();
            var userRole = userRoles.FirstOrDefault(ur => ur.UserId == userId && ur.RoleId == roleId);

            if (userRole == null)
                return NotFound("Kullanıcıya atanmış bu rol bulunamadı!");

            await _userRoleService.TDeleteAsync(userRole);
            return Ok(new { message = "Rol kullanıcıdan kaldırıldı!" });
        }
    }
}

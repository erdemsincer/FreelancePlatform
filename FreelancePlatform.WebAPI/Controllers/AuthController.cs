using FreelancePlatform.Core.DTOs.AuthDtos;
using FreelancePlatform.Core.Entities;
using FreelancePlatform.Services.Abstract;
using FreelancePlatform.Services.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace FreelancePlatform.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private readonly IUserRoleService _userRoleService;
        private readonly TokenHelper _tokenHelper;

        public AuthController(IUserService userService, IRoleService roleService, IUserRoleService userRoleService, TokenHelper tokenHelper)
        {
            _userService = userService;
            _roleService = roleService;
            _userRoleService = userRoleService;
            _tokenHelper = tokenHelper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequest)
        {
            // 1️⃣ E-posta kontrolü
            var existingUser = (await _userService.TGetListAllAsync())
                .FirstOrDefault(u => u.Email == registerRequest.Email);
            if (existingUser != null)
            {
                return BadRequest("Bu e-posta adresi zaten kayıtlı.");
            }

            // 2️⃣ Şifre hashle
            var hashedPassword = PasswordHasher.HashPassword(registerRequest.Password);

            // 3️⃣ Yeni kullanıcı oluştur
            var newUser = new User
            {
                FirstName = registerRequest.FirstName,
                LastName = registerRequest.LastName,
                Email = registerRequest.Email,
                PasswordHash = hashedPassword,
                CreatedAt = DateTime.UtcNow,
                ProfileImageUrl = "https://cdn-icons-png.flaticon.com/512/149/149071.png"
            };

            await _userService.TAddAsync(newUser);

            // 4️⃣ 'User' rolü yoksa oluştur
            var roles = await _roleService.TGetListAllAsync();
            var userRole = roles.FirstOrDefault(r => r.Name == "Freelancer");

            if (userRole == null)
            {
                userRole = new Role
                {
                    Name = "Freelancer",
                   
                };
                await _roleService.TAddAsync(userRole);
            }

            // 5️⃣ Kullanıcıya 'User' rolü ata
            await _userRoleService.AssignRoleAsync(newUser.Id, userRole.Id);

            return Ok(new { message = "Kayıt başarılı! Kullanıcıya 'User' rolü atandı." });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequest)
        {
            var users = await _userService.TGetListAllAsync();
            var currentUser = users.FirstOrDefault(u => u.Email == loginRequest.Email);

            if (currentUser == null)
                return Unauthorized("Kullanıcı bulunamadı!");

            if (!PasswordHasher.VerifyPassword(loginRequest.Password, currentUser.PasswordHash))
                return Unauthorized("Şifre yanlış!");

            // Kullanıcının rollerini al
            var userRoles = await _userRoleService.GetRolesByUserId(currentUser.Id);
            var roleNames = userRoles.Select(ur => ur.Role.Name).ToList();

            var token = _tokenHelper.GenerateToken(currentUser, roleNames);

            var response = new TokenResponseDto
            {
                Token = token,
                Expiration = DateTime.UtcNow.AddMinutes(60),
                Username = $"{currentUser.FirstName} {currentUser.LastName}",
                Roles = roleNames
            };

            return Ok(response);
        }
        }
        }

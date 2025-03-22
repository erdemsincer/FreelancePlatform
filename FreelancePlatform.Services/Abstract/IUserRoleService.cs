using FreelancePlatform.Core.Entities;

namespace FreelancePlatform.Services.Abstract
{
    public interface IUserRoleService : IGenericService<UserRole>
    {
        Task AssignRoleAsync(int userId, int roleId);
        Task<List<UserRole>> GetRolesByUserId(int userId);
        Task<List<UserRole>> GetAllUserRolesAsync();
        
    }
}

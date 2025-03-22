using FreelancePlatform.Core.Entities;

namespace FreelancePlatform.DataAccess.Abstract
{
    public interface IUserRoleDal : IGenericDal<UserRole>
    {
        Task AssignRoleAsync(int userId, int roleId);
        Task<List<UserRole>> GetRolesByUserId(int userId);
        Task<List<UserRole>> GetAllUserRolesAsync();  // User ve Role dahil etmeden listeler
        
    }
}

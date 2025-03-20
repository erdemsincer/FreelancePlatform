using FreelancePlatform.Core.Entities;
using FreelancePlatform.DataAccess.Abstract;
using FreelancePlatform.Services.Abstract;

namespace FreelancePlatform.Services.Concrete
{
    public class UserRoleManager : IUserRoleService
    {
        private readonly IUserRoleDal _userRoleDal;

        public UserRoleManager(IUserRoleDal userRoleDal)
        {
            _userRoleDal = userRoleDal;
        }

        public async Task TAddAsync(UserRole entity)
        {
            await _userRoleDal.AddAsync(entity);
        }

        public async Task TDeleteAsync(UserRole entity)
        {
            await _userRoleDal.DeleteAsync(entity);
        }

        public async Task<UserRole> TGetByIdAsync(int id)
        {
            return await _userRoleDal.GetByIdAsync(id);
        }

        public async Task<List<UserRole>> TGetListAllAsync()
        {
            return await _userRoleDal.GetListAllAsync();
        }

        public async Task TUpdateAsync(UserRole entity)
        {
            await _userRoleDal.UpdateAsync(entity);
        }
        public async Task AssignRoleAsync(int userId, int roleId)
        {
            await _userRoleDal.AssignRoleAsync(userId, roleId);
        }
        public async Task<List<UserRole>> GetRolesByUserId(int userId)
        {
            return await _userRoleDal.GetRolesByUserId(userId);
        }

    }
}

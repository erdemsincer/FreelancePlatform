using FreelancePlatform.Core.Entities;
using FreelancePlatform.DataAccess.Abstract;
using FreelancePlatform.Services.Abstract;

namespace FreelancePlatform.Services.Concrete
{
    public class RoleManager : IRoleService
    {
        private readonly IRoleDal _roleDal;

        public RoleManager(IRoleDal roleDal)
        {
            _roleDal = roleDal;
        }

        public async Task TAddAsync(Role entity)
        {
            await _roleDal.AddAsync(entity);
        }

        public async Task TDeleteAsync(Role entity)
        {
            await _roleDal.DeleteAsync(entity);
        }

        public async Task<Role> TGetByIdAsync(int id)
        {
             return await _roleDal.GetByIdAsync(id);
        }

        public async Task<List<Role>> TGetListAllAsync()
        {
            return await _roleDal.GetListAllAsync();
        }

        public async Task TUpdateAsync(Role entity)
        {
            await _roleDal.UpdateAsync(entity);
        }
    }
}

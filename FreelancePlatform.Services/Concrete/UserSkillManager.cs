using FreelancePlatform.Core.Entities;
using FreelancePlatform.DataAccess.Abstract;
using FreelancePlatform.Services.Abstract;

namespace FreelancePlatform.Services.Concrete
{
    public class UserSkillManager : IUserSkillService
    {
        private readonly IUserSkillDal _userRoleDal;

        public UserSkillManager(IUserSkillDal userRoleDal)
        {
            _userRoleDal = userRoleDal;
        }

        public async Task TAddAsync(UserSkill entity)
        {
            await _userRoleDal.AddAsync(entity);
        }

        public async Task TDeleteAsync(UserSkill entity)
        {
            await _userRoleDal.DeleteAsync(entity);
        }

        public async Task<UserSkill> TGetByIdAsync(int id)
        {
            return await _userRoleDal.GetByIdAsync(id);
        }

        public async Task<List<UserSkill>> TGetListAllAsync()
        {
            return await _userRoleDal.GetListAllAsync();
        }

        public async Task TUpdateAsync(UserSkill entity)
        {
            await _userRoleDal.UpdateAsync(entity);
        }
    }
}

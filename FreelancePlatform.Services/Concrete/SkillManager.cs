using FreelancePlatform.Core.Entities;
using FreelancePlatform.DataAccess.Abstract;
using FreelancePlatform.Services.Abstract;

namespace FreelancePlatform.Services.Concrete
{
    public class SkillManager : ISkillService
    {
        private readonly ISkillDal _skillDal;

        public SkillManager(ISkillDal skillDal)
        {
            _skillDal = skillDal;
        }

        public async Task TAddAsync(Skill entity)
        {
           await _skillDal.AddAsync(entity);
        }

        public async Task TDeleteAsync(Skill entity)
        {
            _skillDal.DeleteAsync(entity);
        }

        public async Task<Skill> TGetByIdAsync(int id)
        {
           return await _skillDal.GetByIdAsync(id);
        }

        public async Task<List<Skill>> TGetListAllAsync()
        {
           return  await _skillDal.GetListAllAsync();
        }

        public async Task TUpdateAsync(Skill entity)
        {
            await _skillDal.UpdateAsync(entity);
        }
    }
}

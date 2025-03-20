using FreelancePlatform.Core.Entities;
using FreelancePlatform.DataAccess.Abstract;
using FreelancePlatform.DataAccess.Contexts;
using FreelancePlatform.DataAccess.Repositories;

namespace FreelancePlatform.DataAccess.EntityFramework
{
    public class EFUserSkillDal : GenericRepository<UserSkill>, IUserSkillDal
    {
        public EFUserSkillDal(ApplicationDbContext context) : base(context)
        {
    }
    }
}

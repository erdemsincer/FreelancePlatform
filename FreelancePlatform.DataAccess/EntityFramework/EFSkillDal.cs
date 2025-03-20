using FreelancePlatform.Core.Entities;
using FreelancePlatform.DataAccess.Abstract;
using FreelancePlatform.DataAccess.Contexts;
using FreelancePlatform.DataAccess.Repositories;

namespace FreelancePlatform.DataAccess.EntityFramework
{
    public class EFSkillDal : GenericRepository<Skill>, ISkillDal
    {
        public EFSkillDal(ApplicationDbContext context) : base(context)
        {
    }
    }
}

using FreelancePlatform.Core.Entities;
using FreelancePlatform.DataAccess.Abstract;
using FreelancePlatform.DataAccess.Contexts;
using FreelancePlatform.DataAccess.Repositories;

namespace FreelancePlatform.DataAccess.EntityFramework
{
    public class EFProjectTaskDal : GenericRepository<ProjectTask>, IProjectTaskDal
    {
        public EFProjectTaskDal(ApplicationDbContext context) : base(context)
        {
         }
    }
}

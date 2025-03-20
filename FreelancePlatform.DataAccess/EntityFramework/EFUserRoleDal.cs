using FreelancePlatform.Core.Entities;
using FreelancePlatform.DataAccess.Abstract;
using FreelancePlatform.DataAccess.Contexts;
using FreelancePlatform.DataAccess.Repositories;

namespace FreelancePlatform.DataAccess.EntityFramework
{
    public class EFUserRoleDal : GenericRepository<UserRole>, IUserRoleDal
    {
        public EFUserRoleDal(ApplicationDbContext context) : base(context)
        {
    }
    }
}

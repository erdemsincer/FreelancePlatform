using FreelancePlatform.Core.Entities;
using FreelancePlatform.DataAccess.Abstract;
using FreelancePlatform.DataAccess.Contexts;
using FreelancePlatform.DataAccess.Repositories;

namespace FreelancePlatform.DataAccess.EntityFramework
{
    public class EFUserDal : GenericRepository<User>, IUserDal
    {
        public EFUserDal(ApplicationDbContext context) : base(context)
        {
        }

       
    }
}

using FreelancePlatform.Core.Entities;
using FreelancePlatform.DataAccess.Abstract;
using FreelancePlatform.DataAccess.Contexts;
using FreelancePlatform.DataAccess.Repositories;

namespace FreelancePlatform.DataAccess.EntityFramework
{
    public class EFBidDal : GenericRepository<Bid>, IBidDal
    {
        public EFBidDal(ApplicationDbContext context) : base(context)
        {
        }
    }
}

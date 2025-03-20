using FreelancePlatform.Core.Entities;
using FreelancePlatform.DataAccess.Abstract;
using FreelancePlatform.DataAccess.Contexts;
using FreelancePlatform.DataAccess.Repositories;

namespace FreelancePlatform.DataAccess.EntityFramework
{
    public class EFReviewDal : GenericRepository<Review>, IReviewDal
    {
        public EFReviewDal(ApplicationDbContext context) : base(context)
        {
    }
    }
}

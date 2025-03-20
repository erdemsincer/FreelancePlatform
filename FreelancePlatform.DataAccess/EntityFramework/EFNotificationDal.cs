using FreelancePlatform.Core.Entities;
using FreelancePlatform.DataAccess.Abstract;
using FreelancePlatform.DataAccess.Contexts;
using FreelancePlatform.DataAccess.Repositories;

namespace FreelancePlatform.DataAccess.EntityFramework
{
    public class EFNotificationDal : GenericRepository<Notification>, INotificationDal
    {
        public EFNotificationDal(ApplicationDbContext context) : base(context)
        {
        }
    }
}

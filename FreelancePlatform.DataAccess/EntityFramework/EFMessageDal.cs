using FreelancePlatform.Core.Entities;
using FreelancePlatform.DataAccess.Abstract;
using FreelancePlatform.DataAccess.Contexts;
using FreelancePlatform.DataAccess.Repositories;

namespace FreelancePlatform.DataAccess.EntityFramework
{
    public class EFMessageDal : GenericRepository<Message>, IMessageDal
    {
        public EFMessageDal(ApplicationDbContext context) : base(context)
        {
        }
    }
}


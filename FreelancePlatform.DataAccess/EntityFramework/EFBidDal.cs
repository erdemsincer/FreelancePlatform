using FreelancePlatform.Core.DTOs.BidDtos;
using FreelancePlatform.Core.Entities;
using FreelancePlatform.DataAccess.Abstract;
using FreelancePlatform.DataAccess.Contexts;
using FreelancePlatform.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FreelancePlatform.DataAccess.EntityFramework
{
    public class EFBidDal : GenericRepository<Bid>, IBidDal
    {
        private readonly ApplicationDbContext _context;
        public EFBidDal(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
       

    }
}

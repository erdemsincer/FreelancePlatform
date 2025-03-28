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
        public async Task<List<Bid>> GetBidsByEmployerIdAsync(int employerId)
        {
            return await _context.Bids
                .Include(b => b.Project)
                .Include(b => b.Freelancer)
                .Where(b => b.Project.EmployerId == employerId)
                .ToListAsync();
        }
        public async Task<Bid> GetBidWithProjectAsync(int bidId)
        {
            return await _context.Bids
                .Include(b => b.Project)
                .FirstOrDefaultAsync(b => b.Id == bidId);
        }



    }
}

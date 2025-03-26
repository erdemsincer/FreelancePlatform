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
        public async Task<List<Bid>> GetBidsByProjectIdAsync(int projectId)
        {
            return await _context.Bids
                .Include(b => b.Freelancer)
                .Where(b => b.ProjectId == projectId)
                .ToListAsync();
        }

        public async Task<List<Bid>> GetBidsByFreelancerIdAsync(int freelancerId)
        {
            return await _context.Bids
                .Include(b => b.Project)
                .Where(b => b.FreelancerId == freelancerId)
                .ToListAsync();
        }
    }
}

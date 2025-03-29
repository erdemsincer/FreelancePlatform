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
        public async Task<List<ResultBidWithProjectDto>> GetBidsByFreelancerIdAsync(int freelancerId)
        {
            return await _context.Bids
                .Where(b => b.FreelancerId == freelancerId)
                .Include(b => b.Project)
                .Select(b => new ResultBidWithProjectDto
                {
                    BidId = b.Id,
                    ProjectId = b.ProjectId,
                    ProjectTitle = b.Project.Title,
                    EmployerId = b.Project.EmployerId,
                    FreelancerId = b.FreelancerId,
                    OfferAmount = b.OfferAmount,
                    Message = b.Message,
                    CreatedAt = b.CreatedAt,
                    ProjectStatus = b.Project.Status
                })
                .ToListAsync();
        }




    }
}

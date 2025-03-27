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
        public async Task AddBidAndUpdateProjectStatusAsync(Bid bid)
        {
            await _context.Bids.AddAsync(bid);

            var project = await _context.Projects.FindAsync(bid.ProjectId);
            if (project != null && project.Status == "Açık")
            {
                project.Status = "Teklif Alınıyor";
                _context.Projects.Update(project);
            }

            await _context.SaveChangesAsync();
        }
        public async Task AcceptBidAsync(int bidId)
        {
            var bid = await _context.Bids.FindAsync(bidId);
            if (bid == null) throw new Exception("Teklif bulunamadı!");

            var project = await _context.Projects.FindAsync(bid.ProjectId);
            if (project == null) throw new Exception("Proje bulunamadı!");

            project.Status = "Kabul Edildi";
            _context.Projects.Update(project);
            await _context.SaveChangesAsync();
        }
        public async Task<List<ResultBidWithProjectDto>> GetBidsByEmployerIdAsync(int employerId)
        {
            return await _context.Bids
                .Include(b => b.Project)
                .Include(b => b.Freelancer)
                .Where(b => b.Project.EmployerId == employerId)
                .Select(b => new ResultBidWithProjectDto
                {
                    BidId = b.Id,
                    ProjectId = b.ProjectId,
                    ProjectTitle = b.Project.Title,
                     FreelancerId= b.FreelancerId,
                    FreelancerName = b.Freelancer.FirstName + " " + b.Freelancer.LastName,
                    OfferAmount = b.OfferAmount,
                    Message = b.Message,
                    CreatedAt = b.CreatedAt
                })
                .ToListAsync();
        }

    }
}

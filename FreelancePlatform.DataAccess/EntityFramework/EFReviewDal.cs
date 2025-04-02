using FreelancePlatform.Core.Entities;
using FreelancePlatform.DataAccess.Abstract;
using FreelancePlatform.DataAccess.Contexts;
using FreelancePlatform.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FreelancePlatform.DataAccess.EntityFramework
{
    public class EFReviewDal : GenericRepository<Review>, IReviewDal
    {
        private readonly ApplicationDbContext _context;
        public EFReviewDal(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Review>> GetReviewsByUserIdAsync(int userId)
        {
            return await _context.Reviews
                .Include(r => r.Reviewer)
                .Include(r => r.Project)
                .Where(r => r.RevieweeId == userId)
                .ToListAsync();
        }
    }
}

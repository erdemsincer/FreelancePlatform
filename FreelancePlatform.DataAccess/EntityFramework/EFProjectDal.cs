using FreelancePlatform.Core.DTOs.ProjectDtos;
using FreelancePlatform.Core.Entities;
using FreelancePlatform.DataAccess.Abstract;
using FreelancePlatform.DataAccess.Contexts;
using FreelancePlatform.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FreelancePlatform.DataAccess.EntityFramework
{
    public class EFProjectDal : GenericRepository<Project>, IProjectDal
    {
        private readonly ApplicationDbContext _context;

        public EFProjectDal(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<ResultProjectDto>> GetAllDetailedProjectsAsync()
        {
            return await _context.Projects
                .Include(p => p.Category)
                .Include(p => p.Employer)
                .Select(p => new ResultProjectDto
                {
                    Id = p.Id,
                    Title = p.Title,
                    Description = p.Description,
                    Budget = p.Budget,
                    CategoryName = p.Category.Name,
                    EmployerFullName = p.Employer.FirstName + " " + p.Employer.LastName,
                    CreatedAt = p.CreatedAt,
                    Deadline = p.Deadline,
                    Status = p.Status
                }).ToListAsync();


        }
        public async Task<Project> GetProjectByIdWithIncludeAsync(int id)
        {
            return await _context.Projects
                .Include(p => p.Category)
                .Include(p => p.Employer)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<List<Project>> GetProjectsByEmployerIdAsync(int employerId)
        {
            return await _context.Projects
                .Where(p => p.EmployerId == employerId)
                .ToListAsync();
        }
        public IQueryable<Project> Query()
        {
            return _context.Projects
                           .Include(p => p.Category);
                           
        }
        public async Task<List<Project>> GetAllProjectsWithCategoryAsync()
        {
            return await _context.Projects
                                 .Include(p => p.Category)
                                 .ToListAsync();
        }
        public async Task<List<Project>> GetCompletedProjectsAsync()
        {
            return await _context.Projects
                .Where(p => p.Status == "Tamamlandı")
                .Include(p => p.Category)
                .Include(p => p.Employer)
                .Take(6)  
                .ToListAsync();
        }
        public async Task<List<Project>> GetCompletedProjectsByFreelancerIdAsync(int freelancerId)
        {
            return await _context.Projects
                .Where(p => p.Status == "Tamamlandı" && p.Bids.Any(b => b.FreelancerId == freelancerId && b.Status == "Kabul Edildi"))
                .Include(p => p.Category)
                .Include(p => p.Employer)
                .ToListAsync();
        }










    }
}

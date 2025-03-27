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

        public async Task<List<ResultProjectDto>> GetAllProjectDetailsAsync()
        {
            var projects = await _context.Projects
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
                })
                .ToListAsync();

            return projects;
        }
        public async Task<ResultProjectDto> GetProjectDetailByIdAsync(int projectId)
        {
            return await _context.Projects
                .Where(p => p.Id == projectId)
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
                })
                .FirstOrDefaultAsync();
        }
        
    }
}

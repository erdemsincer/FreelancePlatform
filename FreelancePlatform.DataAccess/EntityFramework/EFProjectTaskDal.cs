using FreelancePlatform.Core.Entities;
using FreelancePlatform.DataAccess.Abstract;
using FreelancePlatform.DataAccess.Contexts;
using FreelancePlatform.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FreelancePlatform.DataAccess.EntityFramework
{
    public class EFProjectTaskDal : GenericRepository<ProjectTask>, IProjectTaskDal
    {
        private readonly ApplicationDbContext _context;
        public EFProjectTaskDal(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<ProjectTask>> GetTasksByProjectIdAsync(int projectId)
        {
            return await _context.ProjectTasks
                                 .Where(p => p.ProjectId == projectId)
                                 .ToListAsync();
        }
    }
}

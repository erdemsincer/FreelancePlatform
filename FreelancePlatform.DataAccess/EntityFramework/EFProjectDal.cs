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

       
        
    }
}

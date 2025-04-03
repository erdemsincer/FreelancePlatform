using FreelancePlatform.Core.Entities;
using FreelancePlatform.DataAccess.Abstract;
using FreelancePlatform.DataAccess.Contexts;
using FreelancePlatform.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancePlatform.DataAccess.EntityFramework
{
    public class EFAdvertisementDal : GenericRepository<Advertisement>, IAdvertisementDal
    {
        private readonly ApplicationDbContext _context;

        public EFAdvertisementDal(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Advertisement>> GetAllWithIncludesAsync()
        {
            return await _context.Advertisements
                .Include(x => x.Category)
                .Include(x => x.Freelancer)
                .ToListAsync();
        }
        public async Task<List<Advertisement>> GetAdvertisementsByFreelancerIdAsync(int freelancerId)
        {
            return await _context.Advertisements
                .Include(x => x.Category)
                .Include(x => x.Freelancer)
                .Where(x => x.FreelancerId == freelancerId)
                .ToListAsync();
        }


    }

}

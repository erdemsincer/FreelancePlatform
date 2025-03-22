using FreelancePlatform.Core.Entities;
using FreelancePlatform.DataAccess.Abstract;
using FreelancePlatform.DataAccess.Contexts;
using FreelancePlatform.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FreelancePlatform.DataAccess.EntityFramework
{
    public class EFUserRoleDal : GenericRepository<UserRole>, IUserRoleDal
    {
        private readonly ApplicationDbContext _context;

        public EFUserRoleDal(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AssignRoleAsync(int userId, int roleId)
        {
            var userRole = new UserRole
            {
                UserId = userId,
                RoleId = roleId
            };

            await _context.UserRoles.AddAsync(userRole);
            await _context.SaveChangesAsync();
        }
        public async Task<List<UserRole>> GetRolesByUserId(int userId)
        {
            return await _context.UserRoles
                                 .Include(ur => ur.Role)
                                 .Where(ur => ur.UserId == userId)
                                 .ToListAsync();
        }

        public async Task<List<UserRole>> GetAllUserRolesAsync()
        {
            return await _context.UserRoles
        .Include(ur => ur.User)
        .Include(ur => ur.Role)
        .AsNoTracking()
        .ToListAsync();// User ve Role'ü dahil etmiyoruz
        }

       
    }
}

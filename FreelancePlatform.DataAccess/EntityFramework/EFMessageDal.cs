using FreelancePlatform.Core.Entities;
using FreelancePlatform.DataAccess.Abstract;
using FreelancePlatform.DataAccess.Contexts;
using FreelancePlatform.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FreelancePlatform.DataAccess.EntityFramework
{
    public class EFMessageDal : GenericRepository<Message>, IMessageDal
    {
        private readonly ApplicationDbContext _context;
        public EFMessageDal(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<Message>> GetMessagesBetweenUsersAsync(int user1Id, int user2Id)
        {
            return await _context.Messages
                .Include(m => m.Sender)
                .Include(m => m.Receiver)
                .Where(m =>
                    (m.SenderId == user1Id && m.ReceiverId == user2Id) ||
                    (m.SenderId == user2Id && m.ReceiverId == user1Id))
                .OrderBy(m => m.SentAt)
                .ToListAsync();
        }

    }
}


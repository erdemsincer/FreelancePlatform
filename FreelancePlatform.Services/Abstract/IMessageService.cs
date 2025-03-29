using FreelancePlatform.Core.Entities;

namespace FreelancePlatform.Services.Abstract
{
    public interface IMessageService : IGenericService<Message>
    {
        Task<List<Message>> GetConversationAsync(int user1Id, int user2Id);

    }
}

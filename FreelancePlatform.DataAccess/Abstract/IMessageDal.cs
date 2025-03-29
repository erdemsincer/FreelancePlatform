using FreelancePlatform.Core.Entities;

namespace FreelancePlatform.DataAccess.Abstract
{
    public interface IMessageDal: IGenericDal<Message>
    {
        Task<List<Message>> GetMessagesBetweenUsersAsync(int user1Id, int user2Id);

    }
}

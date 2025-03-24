using FreelancePlatform.Core.DTOs.UserDtos;
using FreelancePlatform.Core.Entities;

namespace FreelancePlatform.DataAccess.Abstract
{
    public interface IUserDal : IGenericDal<User>
    {
        Task<List<ResultUserDto>> GetFreelancerUsersAsync();
        Task<User> GetUserDetailAsync(int id);

    }
}

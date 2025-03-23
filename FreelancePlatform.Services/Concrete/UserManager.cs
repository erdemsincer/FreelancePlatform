using FreelancePlatform.Core.DTOs.UserDtos;
using FreelancePlatform.Core.Entities;
using FreelancePlatform.DataAccess.Abstract;
using FreelancePlatform.Services.Abstract;


namespace FreelancePlatform.Services.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public async Task<List<ResultUserDto>> GetFreelancerUsersAsync()
        {
            return await _userDal.GetFreelancerUsersAsync();
        }


        public async Task TAddAsync(User entity)
        {
            await _userDal.AddAsync(entity);
        }

        public async Task TDeleteAsync(User entity)
        {
            await _userDal.DeleteAsync(entity);
        }

        public async Task<User> TGetByIdAsync(int id)
        {
            return await _userDal.GetByIdAsync(id);
        }

        public async Task<List<User>> TGetListAllAsync()
        {
            return await _userDal.GetListAllAsync();
        }

        public async Task TUpdateAsync(User entity)
        {
            await _userDal.UpdateAsync(entity);
        }
    }
}

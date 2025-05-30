﻿using FreelancePlatform.Core.DTOs.UserDtos;
using FreelancePlatform.Core.Entities;

namespace FreelancePlatform.Services.Abstract
{
    public interface IUserService : IGenericService<User>
    {

        Task<List<ResultUserDto>> GetFreelancerUsersAsync();
        Task<User> GetUserDetailAsync(int id);
        Task<ResultUserDto> GetPublicUserInfoAsync(int id);




    }
}

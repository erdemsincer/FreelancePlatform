﻿using FreelancePlatform.Core.DTOs.ProjectDtos;
using FreelancePlatform.Core.Entities;

namespace FreelancePlatform.Services.Abstract
{
    public interface IProjectService : IGenericService<Project>
    {

        Task<List<ResultProjectDto>> GetAllDetailedProjectsAsync();
        Task<Project> GetProjectByIdWithIncludeAsync(int id);


    }
}

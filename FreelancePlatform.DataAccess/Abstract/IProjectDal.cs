﻿using FreelancePlatform.Core.DTOs.ProjectDtos;
using FreelancePlatform.Core.Entities;

namespace FreelancePlatform.DataAccess.Abstract
{
    public interface IProjectDal : IGenericDal<Project>
    {
        Task<List<ResultProjectDto>> GetAllDetailedProjectsAsync();
        Task<Project> GetProjectByIdWithIncludeAsync(int id);



    }
}

using FreelancePlatform.Core.DTOs.ProjectDtos;
using FreelancePlatform.Core.Entities;

namespace FreelancePlatform.Services.Abstract
{
    public interface IProjectService : IGenericService<Project>
    {
        Task<List<ResultProjectDto>> GetAllProjectDetailsAsync();
        Task<ResultProjectDto> GetProjectDetailByIdAsync(int id);


    }
}

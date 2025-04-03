using FreelancePlatform.Core.DTOs.ProjectDtos;
using FreelancePlatform.Core.Entities;

namespace FreelancePlatform.Services.Abstract
{
    public interface IProjectService : IGenericService<Project>
    {

        Task<List<ResultProjectDto>> GetAllDetailedProjectsAsync();
        Task<Project> GetProjectByIdWithIncludeAsync(int id);
        Task<List<Project>> GetProjectsByEmployerIdAsync(int employerId);
        Task<List<Project>> GetAllProjectsWithCategoryAsync();
        Task<List<Project>> GetCompletedProjectsAsync();
        Task<List<Project>> GetCompletedProjectsByFreelancerIdAsync(int freelancerId);






    }
}

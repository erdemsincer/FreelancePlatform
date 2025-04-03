using FreelancePlatform.Core.DTOs.ProjectDtos;
using FreelancePlatform.Core.Entities;

namespace FreelancePlatform.DataAccess.Abstract
{
    public interface IProjectDal : IGenericDal<Project>
    {
        Task<List<ResultProjectDto>> GetAllDetailedProjectsAsync();
        Task<Project> GetProjectByIdWithIncludeAsync(int id);
        Task<List<Project>> GetProjectsByEmployerIdAsync(int employerId);
        Task<List<Project>> GetAllProjectsWithCategoryAsync();
        Task<List<Project>> GetCompletedProjectsAsync();







    }
}

using FreelancePlatform.Core.Entities;

namespace FreelancePlatform.Services.Abstract
{
    public interface IProjectTaskService : IGenericService<ProjectTask>
    {
        Task<List<ProjectTask>> GetTasksByProjectIdAsync(int projectId);
    }
}

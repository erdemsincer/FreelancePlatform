using FreelancePlatform.Core.Entities;

namespace FreelancePlatform.DataAccess.Abstract
{
    public interface IProjectTaskDal : IGenericDal<ProjectTask>
    {
        Task<List<ProjectTask>> GetTasksByProjectIdAsync(int projectId);
    }
}

using FreelancePlatform.Core.Entities;
using FreelancePlatform.DataAccess.Abstract;
using FreelancePlatform.Services.Abstract;

namespace FreelancePlatform.Services.Concrete
{
    public class ProjectTaskManager : IProjectTaskService
    {
        private readonly IProjectTaskDal _projectTaskDal;

        public ProjectTaskManager(IProjectTaskDal projectTaskDal)
        {
            _projectTaskDal = projectTaskDal;
        }

        public async Task TAddAsync(ProjectTask entity)
        {
          await _projectTaskDal.AddAsync(entity);
        }

        public async Task TDeleteAsync(ProjectTask entity)
        {
           await _projectTaskDal.DeleteAsync(entity);
        }

        public async Task<ProjectTask> TGetByIdAsync(int id)
        {
            return await _projectTaskDal.GetByIdAsync(id);
        }

        public async Task<List<ProjectTask>> TGetListAllAsync()
        {
           return await _projectTaskDal.GetListAllAsync();
        }

        public async Task TUpdateAsync(ProjectTask entity)
        {
            await _projectTaskDal.UpdateAsync(entity);
        }
    }
}

using FreelancePlatform.Core.DTOs.ProjectDtos;
using FreelancePlatform.Core.Entities;
using FreelancePlatform.DataAccess.Abstract;
using FreelancePlatform.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancePlatform.Services.Concrete
{
    public class ProjectManager:IProjectService
    {
        private readonly IProjectDal _projectDal;

        public ProjectManager(IProjectDal projectDal)
        {
            _projectDal = projectDal;
        }

        public async Task TAddAsync(Project entity)
        {
            await _projectDal.AddAsync(entity);
        }

        public async Task TDeleteAsync(Project entity)
        {
           await _projectDal.DeleteAsync(entity);
        }

        public async Task<Project> TGetByIdAsync(int id)
        {
           return await _projectDal.GetByIdAsync(id);
        }

        public async Task<List<Project>> TGetListAllAsync()
        {
            return await _projectDal.GetListAllAsync();
        }

        public async Task TUpdateAsync(Project entity)
        {
           await _projectDal.UpdateAsync(entity);
        }
        public async Task<List<ResultProjectDto>> GetAllProjectDetailsAsync()
        {
            return await _projectDal.GetAllProjectDetailsAsync();
        }
        public async Task<ResultProjectDto> GetProjectDetailByIdAsync(int id)
        {
            return await _projectDal.GetProjectDetailByIdAsync(id);
        }

    }
}

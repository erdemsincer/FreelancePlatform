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
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public async Task TAddAsync(Category entity)
        {
            await _categoryDal.AddAsync(entity);
        }

        public async Task TDeleteAsync(Category entity)
        {
            await _categoryDal.DeleteAsync(entity);
        }

        public async Task<Category> TGetByIdAsync(int id)
        {
           return await _categoryDal.GetByIdAsync(id);
        }

        public async Task<List<Category>> TGetListAllAsync()
        {
           return await _categoryDal.GetListAllAsync();
        }

        public async Task TUpdateAsync(Category entity)
        {
            await _categoryDal.UpdateAsync(entity);
        }
    }
}

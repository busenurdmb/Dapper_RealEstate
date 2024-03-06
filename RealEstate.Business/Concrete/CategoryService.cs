using ReakEstate.Entites.Concrete;
using RealEstate.Business.Abstract;
using RealEstate.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Business.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryDal _categoryDAL;

        public CategoryService(ICategoryDal categoryDAL)
        {
            _categoryDAL = categoryDAL;
        }

        public async Task<int> AddCategory(Category category)
        {
             return  await _categoryDAL.Insert(category);
        }

        public async Task<bool> DeleteCategory(int id)
        {
           return await _categoryDAL.Delete(id);
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _categoryDAL.GetAll();
        }

        public async Task<Category> GetCategoryById(int id)
        {
          return await _categoryDAL.GetById(id);
        }

        public async Task<bool> UpdateCategory(Category category)
        {
           return await _categoryDAL.Update(category);
        }
    }
}

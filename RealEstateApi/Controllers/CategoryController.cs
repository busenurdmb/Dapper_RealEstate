using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReakEstate.Entites.Concrete;
using RealEstate.Business.Abstract;
using RealEstate.Business.Concrete;

namespace RealEstateApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _category;

        public CategoryController(ICategoryService category)
        {
            _category = category;
        }

        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            var values = await _category.GetAllCategories();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(Category category)
        {
           await _category.AddCategory(category);
            return Ok("Kategori Başarılı Bir Şekilde Eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(Category category)
        {
          //await  _category.UpdateCategory(category);
          //  return Ok("Kategori Başarıyla Güncellendi");
            bool updated = await _category.UpdateCategory(category);
            if (updated)
            {
                return Ok("Category updated successfully");
            }
            else
            {
                return BadRequest("Failed to update category");
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
           bool deleted=await _category.DeleteCategory(id);
            if (deleted)
            {
                return Ok("Category updated successfully");
            }
            else
            {
                return BadRequest("Failed to update category");
            }
            //return Ok("Kategori Başarılı Bir Şekilde Silindi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var value = await _category.GetCategoryById(id);
            return Ok(value);
        }
    }

}

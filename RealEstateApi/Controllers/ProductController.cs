using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReakEstate.Entites.Concrete;
using RealEstate.Business.Abstract;

namespace RealEstateApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _Product;

        public ProductController(IProductService Product)
        {
            _Product = Product;
        }

        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            var values = await _Product.GetAllProduct();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product Product)
        {
            await _Product.AddProduct(Product);
            return Ok("Kategori Başarılı Bir Şekilde Eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(Product Product)
        {
            //await  _Product.UpdateProduct(Product);
            //  return Ok("Kategori Başarıyla Güncellendi");
            bool updated = await _Product.UpdateProduct(Product);
            if (updated)
            {
                return Ok("Product updated successfully");
            }
            else
            {
                return BadRequest("Failed to update Product");
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            bool deleted = await _Product.DeleteProduct(id);
            if (deleted)
            {
                return Ok("Product updated successfully");
            }
            else
            {
                return BadRequest("Failed to update Product");
            }
            //return Ok("Kategori Başarılı Bir Şekilde Silindi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var value = await _Product.GetProductById(id);
            return Ok(value);
        }
        [HttpGet("ProductListWithCategory")]
        public async Task<IActionResult> ProductListWithCategory()
        {
            var values = await _Product.GetAllProductWithCategory();
            return Ok(values);
        }
    }
}

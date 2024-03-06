using ReakEstate.Entites.Concrete;
using ReakEstate.Entites.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Business.Abstract
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProduct();
        Task<List<ProductCategoryView>> GetAllProductWithCategory();

        Task<Product> GetProductById(int id);
        Task<int> AddProduct(Product Product);
        Task<bool> UpdateProduct(Product Product);
        Task<bool> DeleteProduct(int id);
    }
}

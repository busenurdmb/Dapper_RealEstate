using ReakEstate.Entites.Concrete;
using ReakEstate.Entites.Dto;
using RealEstate.Business.Abstract;
using RealEstate.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Business.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IProductDal _ProductDAL;

        public ProductService(IProductDal ProductDAL)
        {
            _ProductDAL = ProductDAL;
        }

        public async Task<int> AddProduct(Product Product)
        {
            return await _ProductDAL.Insert(Product);
        }

        public async Task<bool> DeleteProduct(int id)
        {
            return await _ProductDAL.Delete(id);
        }

        public async Task<IEnumerable<Product>> GetAllProduct()
        {
            return await _ProductDAL.GetAll();
        }

        public async Task<List<ProductCategoryView>> GetAllProductWithCategory()
        {
            return await _ProductDAL.GetAllProductWithCategory();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _ProductDAL.GetById(id);
        }

        public async Task<bool> UpdateProduct(Product Product)
        {
            return await _ProductDAL.Update(Product);
        }
    }
}

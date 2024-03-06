using Dapper;
using ReakEstate.Entites.Concrete;
using ReakEstate.Entites.Dto;
using RealEstate.Data.Abstract;
using RealEstate.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Data.Concrete.DapperContext
{
    public class DpProductDal : DapperRepository<Product>, IProductDal
    {
        private readonly Context _context;
        public DpProductDal(Context context) : base("Product", context)
        {
            _context = context;
        }

        public async Task<List<ProductCategoryView>> GetAllProductWithCategory()
        {
            string query = "Select ProductID,Title,Price,City,District,CategoryName,CoverImage,Address From Product inner join Category on Product.ProductCategory=Category.CategoryID";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ProductCategoryView>(query);
                return values.ToList();
            }
        }
    }
}

using ReakEstate.Entites.Concrete;
using ReakEstate.Entites.Dto;
using RealEstate.Data.IRepositroy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Data.Abstract
{
    public interface IProductDal : IDapperRepository<Product>
    {
        Task<List<ProductCategoryView>> GetAllProductWithCategory();
    }
}

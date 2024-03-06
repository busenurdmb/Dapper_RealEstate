using ReakEstate.Entites.Concrete;
using RealEstate.Data.Abstract;
using RealEstate.Data.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Data.Concrete.DapperContext
{
    public class DpCategoryDal : DapperRepository<Category>, ICategoryDal
    {
        public DpCategoryDal(Context context) : base("Category", context)
        {

        }
    }
}

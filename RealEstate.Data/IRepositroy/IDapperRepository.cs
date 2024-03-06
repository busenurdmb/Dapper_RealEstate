using ReakEstate.Entites.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Data.IRepositroy
{

    public interface IDapperRepository<T> where T : class, IEntity, new()
        {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<int> Insert(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(int id);
    }
    
}

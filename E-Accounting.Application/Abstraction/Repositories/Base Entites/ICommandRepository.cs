using E_Accounting.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Application.Abstraction.Repositories.Base_Entites
{
    public interface ICommandRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        Task RemoveById(string id);
        void Update (T entity);
        void UpdateRange(IEnumerable<T> entities);
        void Remove (T entity); 
        void RemoveRange (IEnumerable<T> entities);
       
        
    }
}

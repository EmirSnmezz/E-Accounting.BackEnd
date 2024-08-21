using E_Accounting.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Application.Abstraction.Repositories.Base_Entites
{
    public interface IQueryRepository<T> : IRepository<T> where T : BaseEntity
    {
     
        IQueryable<T> GetAll(bool isTracking = true);
        IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate);
        Task<T> GetById(string id);
        Task<T> GetFirstByExpression(Expression<Func<T, bool>> predicate);
        Task<T> GetFirst();
    }
}

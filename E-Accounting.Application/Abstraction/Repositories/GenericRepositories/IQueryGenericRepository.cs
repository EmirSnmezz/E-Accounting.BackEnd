using E_Accounting.Domain.Common;
using E_Accounting.Domain.Repositories.GenericRepositories;
using System.Linq.Expressions;

namespace E_Accounting.Application.Abstraction.Repositories.BaseRepositories
{
    public interface IQueryGenericRepository<T> : IRepository<T>
        where T : BaseEntity
    {
        IQueryable<T> GetAll(bool isTracking = true);
        IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate, bool isTracking = true);
        Task<T> GetById(string id, bool isTracking = true);
        Task<T> GetFirstByExpression(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken, bool isTracking = true);
        Task<T> GetFirst(bool isTracking = true);
    }
}

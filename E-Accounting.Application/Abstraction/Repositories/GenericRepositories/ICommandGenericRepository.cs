using E_Accounting.Domain.Common;

namespace E_Accounting.Application.Abstraction.Repositories.BaseRepositories
{
    public interface ICommandGenericRepository<T> : IRepository<T>
        where T : BaseEntity
    {
        Task AddAsync(T entity, CancellationToken cancellationToken);
        Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken);
        Task RemoveById(string id);
        void Update(T entity);
        void UpdateRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}


using E_Accounting.Application.Abstraction.Repositories.BaseRepositories;
using E_Accounting.Domain.Common;

namespace E_Accounting.Domain.Repositories.GenericRepositories.AppDbContext
{
    public interface IMasterQueryRepository<T> : IQueryGenericRepository<T>, IRepository<T> where T : BaseEntity
    {
    }
}

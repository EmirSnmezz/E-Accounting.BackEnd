using E_Accounting.Domain.Common;
using E_Accounting.Domain.Repositories.GenericRepositories;

namespace E_Accounting.Application.Abstraction.Repositories.BaseRepositories
{
    public interface IQueryRepository<T> : IRepository<T>, IQueryGenericRepository<T>
        where T : BaseEntity
    {

    }
}

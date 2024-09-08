using E_Accounting.Domain.Common;
using E_Accounting.Domain.Repositories.GenericRepositories;

namespace E_Accounting.Application.Abstraction.Repositories.BaseRepositories
{
    public interface ICommandRepository<T> : IRepository<T>, ICommandGenericRepository<T> 
        where T : BaseEntity
    {

    }
}

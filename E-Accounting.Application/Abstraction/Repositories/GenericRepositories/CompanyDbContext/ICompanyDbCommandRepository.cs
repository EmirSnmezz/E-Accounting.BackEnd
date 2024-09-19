using E_Accounting.Application.Abstraction.Repositories.BaseRepositories;
using E_Accounting.Application.Abstraction.Repositories.BaseRepositories.GenericRepositories.CompanyDbContext;
using E_Accounting.Domain.Common;

namespace E_Accounting.Domain.Repositories.GenericRepositories.CompanyDbContext
{
    public interface ICompanyDbCommandRepository<T>:ICompanyDbRepository<T>, ICommandGenericRepository<T>
        where T : BaseEntity
    {
    }
}

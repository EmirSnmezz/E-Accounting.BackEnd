using E_Accounting.Domain.Common;

namespace E_Accounting.Domain.Repositories.GenericRepositories.CompanyDbContext
{
    public interface ICompanyDbCommandRepository<T>: ICommandGenericRepository<T> 
        where T : BaseEntity
    {
    }
}

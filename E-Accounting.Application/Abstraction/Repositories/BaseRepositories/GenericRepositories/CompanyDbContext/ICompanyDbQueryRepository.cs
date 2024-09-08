using E_Accounting.Domain.Common;

namespace E_Accounting.Domain.Repositories.GenericRepositories.CompanyDbContext
{
    public interface ICompanyDbQueryRepository<T> : IQueryGenericRepository<T> where T : BaseEntity
    {
    }
}

using E_Accounting.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace E_Accounting.Application.Abstraction.Repositories.BaseRepositories.GenericRepositories.CompanyDbContext
{
    public interface ICompanyDbRepository<T> : IRepository<T> where T : BaseEntity
    {
        void SetDbContextInstance(DbContext context);
    }
}

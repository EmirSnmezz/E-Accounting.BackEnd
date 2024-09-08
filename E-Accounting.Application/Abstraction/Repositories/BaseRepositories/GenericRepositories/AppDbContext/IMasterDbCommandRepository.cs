
using E_Accounting.Application.Abstraction.Repositories.BaseRepositories;
using E_Accounting.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace E_Accounting.Domain.Repositories.GenericRepositories.AppDbContext
{
    public interface IMasterDbCommandRepository<T> : ICommandGenericRepository<T>, IRepository<T>
        where T : BaseEntity
    {
    }
}

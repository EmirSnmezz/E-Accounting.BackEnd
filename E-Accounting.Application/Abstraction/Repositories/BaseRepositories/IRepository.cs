using E_Accounting.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace E_Accounting.Application.Abstraction.Repositories.BaseRepositories
{
    public interface IRepository<T> 
        where T : BaseEntity
    {
        DbSet<T> Table { get; }
    }
}

using E_Accounting.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Application.Abstraction.Repositories.Base_Entites
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
        void SetDbContextInstance(DbContext context);

    }
}

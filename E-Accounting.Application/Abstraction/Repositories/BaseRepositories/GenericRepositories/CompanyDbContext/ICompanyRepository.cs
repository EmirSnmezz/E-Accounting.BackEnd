using E_Accounting.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Application.Abstraction.Repositories.BaseRepositories.GenericRepositories.CompanyDbContext
{
    public interface ICompanyRepository<T> : IRepository<T> where T : BaseEntity
    {
        void SetDbContextInstance(DbContext context);
    }
}

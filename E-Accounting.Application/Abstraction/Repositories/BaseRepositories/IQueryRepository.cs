using E_Accounting.Domain.Common;
using E_Accounting.Domain.Repositories.GenericRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Application.Abstraction.Repositories.BaseRepositories
{
    public interface IQueryRepository<T> : IRepository<T>, IQueryGenericRepository<T> where T : BaseEntity
    {

    }
}

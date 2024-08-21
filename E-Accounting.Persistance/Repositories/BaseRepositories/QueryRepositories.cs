using E_Accounting.Application.Abstraction.Repositories.Base_Entites;
using E_Accounting.Domain.Common;
using E_Accounting.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Persistance.Repositories.BaseRepositories
{
    public class QueryRepositories<T> : IQueryRepository<T> where T : BaseEntity
    {
        private CompanyDbContext _context;
        public DbSet<T> Table => _context.Set<T>();

        public void CreateDbContext(DbContext context)
        {
            _context = (CompanyDbContext)context;
        }

        public IQueryable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetFirst()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetFirstByExpression(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}

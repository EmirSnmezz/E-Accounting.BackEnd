using E_Accounting.Application.Abstraction.Repositories.Base_Entites;
using E_Accounting.Domain.Common;
using E_Accounting.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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

        public void SetDbContextInstance(DbContext context)
        {
            _context = (CompanyDbContext)context;
        }

        public IQueryable<T> GetAll(bool isTracking = true)
        {
            var query = Table.AsQueryable();

            if (!isTracking)
            {
             query.AsNoTracking();
            }

            return query;

        }

        public async Task<T> GetById(string id)
        {
            T data = await Table.FindAsync(id);
            return data;
        }

        public async Task<T> GetFirst()
        {
           T data = await Table.FirstAsync(); // tablodaki ilk kaydı getirecek
            return data;
        }

        public async Task<T> GetFirstByExpression(Expression<Func<T, bool>> predicate)
        {
            T data = await Table.FirstAsync(predicate);
            return data;
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate)
        {
           IQueryable<T> query = Table.Where(predicate);
            return query;
        }
    }
}

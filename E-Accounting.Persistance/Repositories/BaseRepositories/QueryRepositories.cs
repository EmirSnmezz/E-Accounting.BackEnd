using E_Accounting.Application.Abstraction.Repositories.Base_Entites;
using E_Accounting.Domain.Common;
using E_Accounting.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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

        public async Task<T> GetById(string id, bool isTracking = true)
        {
            T data = await Table.FindAsync(id);

            if (!isTracking)
            {
                var query = await Table.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
                return query;
            }
            return data;
        }

        public async Task<T> GetFirst(bool isTracking = true)
        {
            if(!isTracking)
            {
                var query =  await Table.AsNoTracking().FirstAsync();
                return query;
            }

            T data = await Table.FirstAsync(); // tablodaki ilk kaydı getirecek
            return data;
        }

        public async Task<T> GetFirstByExpression(Expression<Func<T, bool>> predicate, bool isTracking = true)
        {
            Table.AsQueryable();
            T data = await Table.FirstAsync(predicate);
            if (!isTracking)
            {
                var query = await Table.AsNoTracking().FirstOrDefaultAsync(predicate);
                return query;
            }
            return data;
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate, bool isTracking = true)
        {
            Table.AsQueryable();
            IQueryable<T> query = Table.Where(predicate);

            if (!isTracking)
            {
                query.AsNoTracking();
                return query;
            }

            return query;
        }
    }
}

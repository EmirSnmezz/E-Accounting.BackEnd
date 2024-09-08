using E_Accounting.Domain.Common;
using E_Accounting.Domain.Repositories.GenericRepositories.CompanyDbContext;
using E_Accounting.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace E_Accounting.Persistance.Repositories.GenericRepositories.CompanyDbContextRepository.BaseRepositories
{
    public class CompanyQueryRepository<T> : ICompanyDbQueryRepository<T> where T : BaseEntity
    {
        private readonly CompanyDbContext _context;

        public CompanyQueryRepository(CompanyDbContext context)
        {
            _context = context;
            Table = _context.Set<T>();
        }

        public DbSet<T> Table { get; set; } 

        public IQueryable<T> GetAll(bool isTracking = true)
        {
            return Table.AsQueryable();
        }

        public async Task<T> GetById(string id, bool isTracking = true)
        {
            return await Table.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<T> GetFirst(bool isTracking = true)
        {
            return await Table.FirstAsync();
        }

        public async Task<T> GetFirstByExpression(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken, bool isTracking = true)
        {
            T entity = await Table.FirstOrDefaultAsync(predicate);
            return entity;
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate, bool isTracking = true)
        {
            IQueryable<T> entites = Table.Where(predicate);
            return entites;
        }
    }
}

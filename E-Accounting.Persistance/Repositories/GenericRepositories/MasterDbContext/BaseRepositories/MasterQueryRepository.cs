using E_Accounting.Domain.Common;
using E_Accounting.Domain.Repositories.GenericRepositories.AppDbContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace E_Accounting.Persistance.Repositories.GenericRepositories.MasterDbContext.BaseRepositories
{
    public class MasterQueryRepository<T> : IMasterDbQueryRepository<T> where T : BaseEntity
    {
        private Contexts.MasterDbContext _context;

        public MasterQueryRepository(Contexts.MasterDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();


        public IQueryable<T> GetAll(bool isTracking = true)
        {
            IQueryable<T> entities = Table.AsQueryable();
            if (!isTracking)
            {
                return entities.AsNoTracking();
            }
            return entities;
        }

        public async Task<T> GetById(string id, bool isTracking = true)
        {
            if (!isTracking)
            {
                var noTrackinhEntity = await Table.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
                return noTrackinhEntity;
            }

            var entity = await Table.FirstOrDefaultAsync(x => x.Id == id);
            return entity;
        }

        public async Task<T> GetFirst(bool isTracking = true)
        {
            if (!isTracking)
            {
                var noTrackingEntity = await Table.AsNoTracking().FirstAsync();
                return noTrackingEntity;
            }

            var entity = await Table.FirstAsync();
            return entity;
        }

        public async Task<T> GetFirstByExpression(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken, bool isTracking = true)
        {
            if (!isTracking)
            {
                var noTrackingEntity = await Table.AsNoTracking().FirstOrDefaultAsync(predicate);
                return noTrackingEntity;
            }

            var entity = await Table.FirstOrDefaultAsync(predicate);
            return entity;
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate, bool isTracking = true)
        {
            if (!isTracking)
            {
                var noTrackingEntity = Table.Where(predicate).ToList().AsQueryable();
                return noTrackingEntity;
            }

            var entity = Table.Where(predicate).ToList().AsQueryable();
            return entity;
        }
    }
}

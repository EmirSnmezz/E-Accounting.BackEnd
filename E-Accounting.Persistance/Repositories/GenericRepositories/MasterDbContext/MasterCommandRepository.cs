using E_Accounting.Domain.Common;
using E_Accounting.Domain.Repositories.GenericRepositories.AppDbContext;
using Microsoft.EntityFrameworkCore;

namespace E_Accounting.Persistance.Repositories.GenericRepositories.MasterDbContext
{
    public class MasterCommandRepository<T> : IMasterCommandRepository<T> where T : BaseEntity
    {
        private  Contexts.MasterDbContext _context;

        public MasterCommandRepository(Contexts.MasterDbContext context)
        {
            _context = context;
            Table = _context.Set<T>();
        }

        public void SetDbContextInstance(DbContext context)
        {
            _context = (Contexts.MasterDbContext)context;
        }

        public DbSet<T> Table { get; set; } 

        public async Task AddAsync(T entity, CancellationToken cancellationToken)
        {
           await Table.AddAsync(entity, cancellationToken);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken)
        {
           await Table.AddRangeAsync(entities, cancellationToken);
        }

        public void Remove(T entity)
        {
            Table.Remove(entity);
        }

        public async Task RemoveById(string id)
        {
            T entity = await Table.FirstOrDefaultAsync( x => x.Id == id);
             Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            Table.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            Table.Update(entity);
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            Table.UpdateRange(entities);
        }
    }
}

using E_Accounting.Application.Abstraction.Repositories.Base_Entites;
using E_Accounting.Domain.Common;
using E_Accounting.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Persistance.Repositories.BaseRepositories
{
    public class CommandRepositories<T> : ICommandRepository<T> where T : BaseEntity
    {
        private CompanyDbContext _context;

        public DbSet<T> Table => _context.Set<T>();

        public void SetDbContextInstance(DbContext context)
        {
            _context = (CompanyDbContext)context;
        }
        public async Task AddAsync(T entity, CancellationToken cancellationToken)
        {
            EntityEntry<T> entityEntry = await Table.AddAsync(entity, cancellationToken);
            entityEntry.State = EntityState.Added;
        }

        public async Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken)
        {
            await Table.AddRangeAsync(entities, cancellationToken);
        }

        public void Remove(T entity)
        {
            EntityEntry<T> entityEntry = Table.Remove(entity);
            entityEntry.State = EntityState.Deleted;
        }

        public async Task RemoveById(string id)
        {
           T deletedEntity = await Table.FindAsync(id);
            Remove(deletedEntity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            Table.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            EntityEntry<T> entityEntry = Table.Update(entity);
            entityEntry.State = EntityState.Modified;   
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            Table.UpdateRange(entities);
        }
    }
}

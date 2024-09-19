using E_Accounting.Domain.Common;
using E_Accounting.Domain.Entities.App_Entites;
using E_Accounting.Domain.Repositories.GenericRepositories.CompanyDbContext;
using E_Accounting.Persistance.Context;
using E_Accounting.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;

namespace E_Accounting.Persistance.Repositories.GenericRepositories.CompanyDbContextRepository.BaseRepositories
{
    public class CompanyDbCommandRepository<T> : ICompanyDbCommandRepository<T> where T : BaseEntity
    {
        private CompanyDbContext _companyDbContext;
        public void SetDbContextInstance(DbContext context)
        {
            _companyDbContext = (CompanyDbContext)context;
            Table = _companyDbContext.Set<T>();
        }

        public DbSet<T> Table {  get; set; }    

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
           T entity = await Table.FirstOrDefaultAsync(x => x.Id == id); 
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

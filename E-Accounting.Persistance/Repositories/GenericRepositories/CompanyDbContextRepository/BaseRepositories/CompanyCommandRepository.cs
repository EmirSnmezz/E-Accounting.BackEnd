using E_Accounting.Domain.Common;
using E_Accounting.Domain.Entities.App_Entites;
using E_Accounting.Domain.Repositories.GenericRepositories.CompanyDbContext;
using E_Accounting.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;

namespace E_Accounting.Persistance.Repositories.GenericRepositories.CompanyDbContextRepository.BaseRepositories
{
    public class CompanyCommandRepository<T> : ICompanyDbCommandRepository<T> where T : BaseEntity
    {
        private readonly CompanyDbContext _companyDbContext;

        public CompanyCommandRepository(CompanyDbContext companyDbContext)
        {
            _companyDbContext = companyDbContext;
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

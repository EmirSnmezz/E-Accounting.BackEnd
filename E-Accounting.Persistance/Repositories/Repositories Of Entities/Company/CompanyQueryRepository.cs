using E_Accounting.Application.Abstraction.Repositories.BaseRepositories;
using E_Accounting.Domain.Entities.App_Entites;
using E_Accounting.Persistance.Contexts;
using E_Accounting.Persistance.Repositories.GenericRepositories.MasterDbContext;

namespace E_Accounting.Persistance.Repositories.Repositories_Of_Entities
{
    public class CompanyQueryRepository : MasterQueryRepository<Company>, IQueryRepository<Company>
    {
        public CompanyQueryRepository(MasterDbContext context) : base(context)
        {
        }
    }
}

using E_Accounting.Application.Abstraction.Repositories.Repositories_Of_Entities.MasterDbContext.CompanyRepositories;
using E_Accounting.Domain.Entities.App_Entites;
using E_Accounting.Persistance.Repositories.GenericRepositories.MasterDbContext.BaseRepositories;

namespace E_Accounting.Persistance.Repositories.GenericRepositories.MasterDbContext.CompanyRepositories
{
    public class CompanyQueryRepository : MasterQueryRepository<Company>, ICompanyQueryRepository
    {
        public CompanyQueryRepository(Contexts.MasterDbContext context) : base(context)
        {
        }
    }
}

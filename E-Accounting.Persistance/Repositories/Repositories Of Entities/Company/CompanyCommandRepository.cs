using E_Accounting.Application.Abstraction.Repositories.Repositories_Of_Entities.MasterDbContext.CompanyRepositories;
using E_Accounting.Domain.Entities.App_Entites;
using E_Accounting.Domain.Repositories.GenericRepositories.CompanyDbContext;
using E_Accounting.Persistance.Contexts;
using E_Accounting.Persistance.Repositories.GenericRepositories.MasterDbContext.BaseRepositories;

namespace E_Accounting.Persistance.Repositories.Repositories_Of_Entities
{
    public class CompanyCommandRepository : MasterCommandRepository<Company>, ICompanyCommandRepository
    {
        public CompanyCommandRepository(MasterDbContext context) : base(context)
        {
        }
    }
}

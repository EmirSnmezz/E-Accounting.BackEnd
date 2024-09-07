using E_Accounting.Application.Abstraction.Repositories.Repositories_Of_Entities.UCAF_Repositories;
using E_Accounting.Domain.Entities.CompanyEntities;
using E_Accounting.Persistance.Contexts;
using E_Accounting.Persistance.Repositories.GenericRepositories.MasterDbContext.BaseRepositories;

namespace E_Accounting.Persistance.Repositories.Repositories_Of_Entities.UCAF_Repositories
{
    public sealed class UCAFCommandRepository : MasterCommandRepository<UniformChartOfAccount>, IUCAFCommandRepository
    {
        public UCAFCommandRepository(MasterDbContext context) : base(context)
        {
        }
    }
}

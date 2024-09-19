using E_Accounting.Application.Abstraction.Repositories.BaseRepositories;
using E_Accounting.Domain.Entities.CompanyEntities;
using E_Accounting.Domain.Repositories.GenericRepositories.CompanyDbContext;
using Microsoft.EntityFrameworkCore;

namespace E_Accounting.Application.Abstraction.Repositories.Repositories_Of_Entities.UCAF_Repositories
{
    public interface IUCAFCommandRepository : ICompanyDbCommandRepository<UniformChartOfAccount>
    {
    }
}

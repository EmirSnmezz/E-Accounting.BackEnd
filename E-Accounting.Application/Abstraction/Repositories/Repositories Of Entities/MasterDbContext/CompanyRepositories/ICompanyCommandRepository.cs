using E_Accounting.Domain.Entities.App_Entites;
using E_Accounting.Domain.Repositories.GenericRepositories.AppDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Application.Abstraction.Repositories.Repositories_Of_Entities.MasterDbContext.CompanyRepositories
{
    public interface ICompanyCommandRepository : IMasterDbCommandRepository<Company>
    {
    }
}

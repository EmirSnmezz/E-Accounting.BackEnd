using E_Accounting.Application.Abstraction.Repositories.Base_Entites;
using E_Accounting.Domain.Entities.App_Entites;
using E_Accounting.Persistance.Repositories.BaseRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Persistance.Repositories.Repositories_Of_Entities
{
    public class CompanyCommandRepository : CommandRepositories<Company>, ICommandRepository<Company>
    {
    }
}

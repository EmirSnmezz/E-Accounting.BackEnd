using E_Accounting.Application.Abstraction.Repositories.Repositories_Of_Entities.UCAF_Repositories;
using E_Accounting.Domain.Entities.CompanyEntities;
using E_Accounting.Persistance.Repositories.BaseRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Persistance.Repositories.Repositories_Of_Entities.UCAF_Repositories
{
    public sealed class UCAFCommandRepository : CommandRepositories<UniformChartOfAccount>, IUCAFCommandRepository
    {
    }
}

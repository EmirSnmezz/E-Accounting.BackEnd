using E_Accounting.Application.Abstraction.Repositories.BaseRepositories;
using E_Accounting.Domain.Entities.CompanyEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace E_Accounting.Application.Abstraction.Repositories.Repositories_Of_Entities.UCAF_Repositories
{
    public interface IUCAFCommandRepository : ICommandRepository<UniformChartOfAccount>
    {
    }
}

using E_Accounting.Domain.Entities.CompanyEntities;
using E_Accounting.Domain.Repositories.GenericRepositories.CompanyDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Application.Abstraction.Repositories.CompanyDbContext.ReportRepositories
{
    public interface IReportCommandRepository : ICompanyDbCommandRepository<Report>
    {
    }
}

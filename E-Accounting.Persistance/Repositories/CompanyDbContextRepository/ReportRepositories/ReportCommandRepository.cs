using E_Accounting.Application.Abstraction.Repositories.CompanyDbContext.ReportRepositories;
using E_Accounting.Domain.Entities.CompanyEntities;
using E_Accounting.Persistance.Repositories.GenericRepositories.CompanyDbContextRepository.BaseRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Persistance.Repositories.CompanyDbContextRepository.ReportRepositories
{
    public sealed class ReportCommandRepository : CompanyDbCommandRepository<Report>, IReportCommandRepository
    {
    }
}

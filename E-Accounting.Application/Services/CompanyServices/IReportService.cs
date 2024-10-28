using E_Accounting.Application.Features.CompanyFeatures.ReportFeatures.Commands.RequestReport;
using E_Accounting.Domain.Entities.CompanyEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Application.Services.CompanyServices
{
    public interface IReportService
    {
        Task Request(RequestReportCommand request, CancellationToken cancellationToken);
        Task<IList<Report>> GetAllReportsByCompanyId(string companyId);
    }
}

using E_Accounting.Domain.Entities.CompanyEntities;

namespace E_Accounting.Application.Features.CompanyFeatures.ReportFeatures.Queries.GetAllReport;
    public sealed record GetAllReportQueryResponse(IList<Report> Data);

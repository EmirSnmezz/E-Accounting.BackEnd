using E_Accounting.Application.Messaging;

namespace E_Accounting.Application.Features.CompanyFeatures.ReportFeatures.Queries.GetAllReport;
public sealed record GetAllReportQuery(string companyId) : IQuery<GetAllReportQueryResponse>;

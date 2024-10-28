using E_Accounting.Application.Messaging;
using E_Accounting.Application.Services.CompanyServices;

namespace E_Accounting.Application.Features.CompanyFeatures.ReportFeatures.Queries.GetAllReport;
public sealed record GetAllReportQueryHandler : IQueryHandler<GetAllReportQuery, GetAllReportQueryResponse>
{

    private readonly IReportService 
        _reportService;

    public GetAllReportQueryHandler(IReportService reportService)
    {
        _reportService = reportService;
    }
    public async Task<GetAllReportQueryResponse> Handle(GetAllReportQuery request, CancellationToken cancellationToken)
    {
        return new(await _reportService.GetAllReportsByCompanyId(request.companyId));
    }
}

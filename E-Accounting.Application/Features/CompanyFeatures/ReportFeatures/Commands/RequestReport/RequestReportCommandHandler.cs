using E_Accounting.Application.Messaging;
using E_Accounting.Application.Services.CompanyServices;
using E_Accounting.Domain.Entities.CompanyEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Application.Features.CompanyFeatures.ReportFeatures.Commands.RequestReport
{
    public sealed record RequestReportCommandHandler : ICommandHandler<RequestReportCommand, RequestReportCommandResponse>
    {
        private readonly IReportService _reportService;

        public RequestReportCommandHandler(IReportService reportService)
        {
            _reportService = reportService;
        }

        public async Task<RequestReportCommandResponse> Handle(RequestReportCommand request, CancellationToken cancellationToken)
        {
            await _reportService.Request(request, cancellationToken);
            return new();
        }
    }
}

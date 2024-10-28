using E_Accounted_BackEnd.Presentation.Abstraction;
using E_Accounting.Application.Features.CompanyFeatures.ReportFeatures.Commands.RequestReport;
using E_Accounting.Application.Features.CompanyFeatures.ReportFeatures.Queries.GetAllReport;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounted_BackEnd.Presentation.Controllers
{
    public class ReportController : ApiController
    {
        public ReportController(IMediator mediator) : base(mediator) { }

        [HttpPost("[action]")]
        public async Task<IActionResult> RequestReport(RequestReportCommand request, CancellationToken cancellationToken)
        {
            RequestReportCommandResponse response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> GetAllReport(GetAllReportQuery request, CancellationToken cancellationToken)
        {
            GetAllReportQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}

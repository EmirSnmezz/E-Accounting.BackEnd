using E_Accounted_BackEnd.Presentation.Abstraction;
using E_Accounting.Application.Features.Company_Features.UCAFFeautres.Commands.CreateUCAF;
using E_Accounting.Application.Features.CompanyFeatures.UCAFFeautres.Commands.CreateMainUCAF;
using E_Accounting.Application.Features.CompanyFeatures.UCAFFeautres.Commands.RemoveUCAF;
using E_Accounting.Application.Features.CompanyFeatures.UCAFFeautres.Commands.UpdateUCAF;
using E_Accounting.Application.Features.CompanyFeatures.UCAFFeautres.Queries.GetAllUCAF;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace E_Accounted_BackEnd.Presentation.Controllers
{
    public class UCAFSController : ApiController
    {
        public UCAFSController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateUCAF(CreateUCAFCommand request, CancellationToken cancellationToken)
        {
            CreateUCAFCommandResponse response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateMainUCAF(CreateMainUCAFCommand request, CancellationToken cancellationToken)
        {
            CreateMainUCAFCommandResponse response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> GetAllUCAF(GetAllUCAFQuery request)
        {
            GetAllUCAFQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> RemoveByIdUcaf(RemoveUCAFCommand request, CancellationToken cancellationToken)
        {
            RemoveUCAFCommandResonse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateUCAF(UpdateUCAFCommand request, CancellationToken cancellationToken)
        {
            UpdateUCAFCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}

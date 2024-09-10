using E_Accounted_BackEnd.Presentation.Abstraction;
using E_Accounting.Application.Features.MasterFeatures.MainRoleAndRoleRelationShipFeatures.Commands.Create;
using E_Accounting.Application.Features.MasterFeatures.MainRoleAndRoleRelationShipFeatures.Commands.Update;
using E_Accounting.Application.Features.MasterFeatures.MainRoleAndRoleRelationShipFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounted_BackEnd.Presentation.Controllers
{
    public class MainRoleAndRoleRelationShipsController : ApiController
    {
        public MainRoleAndRoleRelationShipsController(IMediator mediator) : base(mediator)
        {}

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateAsync(CreateMainRoleAndRoleRelationShipCommand request, CancellationToken cancellationToken)
        {
            CreateMainRoleAndRoleRelationShipsCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            GetAllMainRoleAndRoleRelationShipQuery request = new();
            GetAllMainRoleAndRoleRelationShipQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Update(UpdateMainRoleAndRoleRelationShipCommand request, CancellationToken cancellationToken)
        {
            UpdateMainRoleAndRoleRelationShipCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}

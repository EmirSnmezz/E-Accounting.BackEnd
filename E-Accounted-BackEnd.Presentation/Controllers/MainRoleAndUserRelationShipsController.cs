using E_Accounted_BackEnd.Presentation.Abstraction;
using E_Accounting.Application.Features.MasterFeatures.MainRoleAndUserRelationShipFeatures.Command.Create;
using E_Accounting.Application.Features.MasterFeatures.MainRoleAndUserRelationShipFeatures.Command.Remove;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounted_BackEnd.Presentation.Controllers
{
    public class MainRoleAndUserRelationShipsController : ApiController
    {
        public MainRoleAndUserRelationShipsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create(CreateMainRoleAndUserRelationShipCommand request, CancellationToken cancellationToken)
        {
            CreateMainRoleAndUserRelationShipCommandResponse response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Remove(RemoveMainRoleAndUserRelationShipCommand request, CancellationToken cancellationToken)
        {
            RemoveMainRoleAndUserRelationShipCommandResponse response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }
    }
}

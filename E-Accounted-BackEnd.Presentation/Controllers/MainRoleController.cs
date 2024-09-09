using E_Accounted_BackEnd.Presentation.Abstraction;
using E_Accounting.Application.Features.MasterFeatures.MainRoleFeatures.Commands.CreateRole;
using E_Accounting.Application.Features.MasterFeatures.MainRoleFeatures.Commands.CreateStaticRoles;
using E_Accounting.Application.Features.MasterFeatures.MainRoleFeatures.Commands.RemoveMainRole;
using E_Accounting.Application.Features.MasterFeatures.MainRoleFeatures.Commands.UpdateMainRole;
using E_Accounting.Application.Features.MasterFeatures.MainRoleFeatures.Queries.GetAllMainRoleQuery;
using E_Accounting.Domain.Roles;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounted_BackEnd.Presentation.Controllers
{
    public class MainRoleController : ApiController
    {
        public MainRoleController(IMediator mediator) : base(mediator)
        {
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateMainRole(CreateMainRoleCommand request, CancellationToken cancellationToken)
        {
            CreateMainRoleCommandResponse response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateStaticMainRole(CancellationToken cancellationToken)
        {
            CreateStaticMainRolesCommand request = new(RoleList.GetStaticMainRoles().ToList());
            CreateStaticMainRolesCommandResponse response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllMainRoles()
        {
            GetAllMainRolesQuery request = new GetAllMainRolesQuery();
            GetAllMainRolesQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> RemoveMainRole(RemoveMainRoleCommand request, CancellationToken cancellationToken)
        {
            RemoveMainRoleCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateMainRole(UpdateMainRoleCommand request, CancellationToken cancellationToken)
        {
            UpdateMainRoleCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}

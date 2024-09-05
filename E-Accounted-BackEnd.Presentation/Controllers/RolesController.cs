using E_Accounted_BackEnd.Presentation.Abstraction;
using E_Accounting.Application.Features.CompanyFeatures.Role_Features.CreateAllRoles;
using E_Accounting.Application.Features.Role_Features;
using E_Accounting.Application.Features.Role_Features.Commands.RemoveRole;
using E_Accounting.Application.Features.Role_Features.Commands.UpdateRole;
using E_Accounting.Application.Features.Role_Features.Queries.GetAllRoles;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace E_Accounted_BackEnd.Presentation.Controllers
{
    public class RolesController : ApiController
    {
        public RolesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateRole(CreateRoleCommand request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> CreateAllRoles()
        {
            var request = new CreateAllRolesCommand();
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllRoles()
        {
            GetAllRolesQuery request = new();
            GetAllRolesQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateRole(UpdateRoleCommand request)
        {
            UpdateRoleCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> RemoveRole(RemoveRoleCommand request)
        {
            RemoveRoleCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

    }
}

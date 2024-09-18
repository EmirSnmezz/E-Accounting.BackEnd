using E_Accounted_BackEnd.Presentation.Abstraction;
using E_Accounting.Application.Features.MasterFeatures.AuthenticationFeatures.Commands.Login;
using E_Accounting.Application.Features.MasterFeatures.AuthenticationFeatures.Queries.GetUserRolesByUserIdAndCompanyId;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounted_BackEnd.Presentation.Controllers
{
    public class AuthController : ApiController
    {
        public AuthController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginCommand loginRequest)
        {
            LoginCommandResponse response = await _mediator.Send(loginRequest);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> GetRolesByUserIdAndCompanyId(GetUserRolesByUserIdAndCompanyIdQuery request, CancellationToken cancellationToken)
        {
            GetUserRolesByUserIdAndCompanyIdQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}

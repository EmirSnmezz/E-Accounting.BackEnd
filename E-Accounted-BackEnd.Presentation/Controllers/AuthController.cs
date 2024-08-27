using E_Accounted_BackEnd.Presentation.Abstraction;
using E_Accounting.Application.Features.MasterFeatures.MasterUserFeatures.Login;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}

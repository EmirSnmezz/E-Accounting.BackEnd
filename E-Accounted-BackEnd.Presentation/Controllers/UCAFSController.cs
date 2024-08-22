using E_Accounted_BackEnd.Presentation.Abstraction;
using E_Accounting.Application.Features.Company_Features.UCAFFeautres.Commands.CreateUCAF;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounted_BackEnd.Presentation.Controllers
{
    public class UCAFSController : ApiController
    {
        public UCAFSController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateUCAF(CreateUCAFRequest request)
        {
            CreateUCAFResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}

using E_Accounted_BackEnd.Presentation.Abstraction;
using E_Accounting.Application.Features.CompanyFeatures.Commands.CreateCompany;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounted_BackEnd.Presentation.Controllers
{
    public class CompainiesController : ApiController
    {
        public CompainiesController(IMediator mediator) : base(mediator) 
        {
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateCompany(CreateCompanyRequest request)
        {
            CreateCompanyResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}

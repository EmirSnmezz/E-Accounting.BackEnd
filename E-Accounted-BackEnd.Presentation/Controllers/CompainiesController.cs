using E_Accounted_BackEnd.Presentation.Abstraction;
using E_Accounting.Application.Features.MasterFeatures.CompanyFeatures.Commands.CreateCompany;
using E_Accounting.Application.Features.MasterFeatures.CompanyFeatures.Commands.MigrateCompanyDatabase;
using E_Accounting.Application.Features.MasterFeatures.CompanyFeatures.Commands.UpdateCompany;
using E_Accounting.Application.Features.MasterFeatures.CompanyFeatures.Queries;
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
        public async Task<IActionResult> CreateCompany(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            CreateCompanyCommandResponse response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> MigrateCompanyDatabases()
        {
            MigrateDatabaseCommand request = new();
            MigrateDatabaseCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllCompanies()
        {
            GetAllCompaniesQuery request = new();
            GetAllCompaniesQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateCompany(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            UpdateCompanyCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}

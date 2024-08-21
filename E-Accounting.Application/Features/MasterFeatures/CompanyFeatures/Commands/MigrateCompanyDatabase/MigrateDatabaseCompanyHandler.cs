using E_Accounting.Application.Services.MasterService;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Application.Features.MasterFeatures.CompanyFeatures.Commands.MigrateCompanyDatabase
{
    public sealed class MigrateDatabaseCompanyHandler : IRequestHandler<MigrateDatabaseCompanyRequest, MigrateDatabaseCompanyResponse>
    {
        private readonly ICompanyService _companyService;
        public MigrateDatabaseCompanyHandler(ICompanyService service)
        {
            _companyService = service;
        }
        public async Task<MigrateDatabaseCompanyResponse> Handle(MigrateDatabaseCompanyRequest request, CancellationToken cancellationToken)
        {
            await _companyService.MigrateCompanyDatabase();
            return new();
        }
    }
}

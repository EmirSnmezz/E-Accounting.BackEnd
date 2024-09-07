using E_Accounting.Application.Messaging;
using E_Accounting.Application.Services.MasterService;
using E_Accounting.Domain.Entities.App_Entites;
using Microsoft.EntityFrameworkCore;

namespace E_Accounting.Application.Features.MasterFeatures.CompanyFeatures.Queries
{
    public class GetAllCompaniesQueryHandler : IQueryHandler<GetAllCompaniesQuery, GetAllCompaniesQueryResponse>
    {
        private readonly ICompanyService _companyService;

        public GetAllCompaniesQueryHandler(ICompanyService companyService)
        {
            _companyService = companyService;    
        }

        public async Task<GetAllCompaniesQueryResponse> Handle(GetAllCompaniesQuery request, CancellationToken cancellationToken)
        {
            IQueryable<Company> result = _companyService.GetAll();
            return new(await result.ToListAsync());
        }
    }
}

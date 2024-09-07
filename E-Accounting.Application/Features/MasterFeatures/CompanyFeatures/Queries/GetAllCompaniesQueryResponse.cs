using E_Accounting.Domain.Entities.App_Entites;

namespace E_Accounting.Application.Features.MasterFeatures.CompanyFeatures.Queries
{
    public record GetAllCompaniesQueryResponse
        (
            List<Company> Companies
        );
}

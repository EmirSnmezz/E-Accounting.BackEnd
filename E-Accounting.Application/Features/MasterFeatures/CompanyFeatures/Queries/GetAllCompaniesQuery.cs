using E_Accounting.Application.Messaging;

namespace E_Accounting.Application.Features.MasterFeatures.CompanyFeatures.Queries
{
    public record GetAllCompaniesQuery() : IQuery<GetAllCompaniesQueryResponse>;
}

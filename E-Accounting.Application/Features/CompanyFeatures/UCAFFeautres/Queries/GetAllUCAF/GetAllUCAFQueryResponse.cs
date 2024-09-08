using E_Accounting.Domain.Entities.CompanyEntities;

namespace E_Accounting.Application.Features.CompanyFeatures.UCAFFeautres.Queries.GetAllUCAF;
public record GetAllUCAFQueryResponse
    (
        IQueryable<UniformChartOfAccount> UCAFs
    );

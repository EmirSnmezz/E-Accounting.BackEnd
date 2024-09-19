using E_Accounting.Application.Messaging;
using E_Accounting.Application.Services.CompanyService;
using E_Accounting.Domain.Entities.CompanyEntities;

namespace E_Accounting.Application.Features.CompanyFeatures.UCAFFeautres.Queries.GetByCodeUCAF;
public sealed record GetByCodeUCAFQueryHandler : IQueryHandler<GetByCodeUCAFQuery, GetByCodeUCAFQueryResponse>
{
    private readonly IUCAFService _ucafService;
    public GetByCodeUCAFQueryHandler(IUCAFService ucafService)
    {
        _ucafService = ucafService;
    }

    public async Task<GetByCodeUCAFQueryResponse> Handle(GetByCodeUCAFQuery request, CancellationToken cancellationToken)
    {
        UniformChartOfAccount result = await _ucafService.GetByCodeAsync(request.companyId, request.code, cancellationToken);
        return new(result);
    }
}


using E_Accounting.Application.Messaging;

namespace E_Accounting.Application.Features.CompanyFeatures.UCAFFeautres.Queries.GetByCodeUCAF;
    public sealed record GetByCodeUCAFQuery(string companyId, string code) : IQuery<GetByCodeUCAFQueryResponse>;


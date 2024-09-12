using E_Accounting.Application.Messaging;

namespace E_Accounting.Application.Features.MasterFeatures.AuthenticationFeatures.Queries.GetUserRolesByUserIdAndCompanyId;
public sealed record GetUserRolesByUserIdAndCompanyIdQuery(
        string UserId,
        string CompanyId
    ) : IQuery<GetUserRolesByUserIdAndCompanyIdQueryResponse>;


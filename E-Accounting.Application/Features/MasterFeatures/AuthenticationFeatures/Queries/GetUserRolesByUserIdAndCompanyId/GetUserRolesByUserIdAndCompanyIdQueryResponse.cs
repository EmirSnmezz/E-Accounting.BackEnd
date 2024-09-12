namespace E_Accounting.Application.Features.MasterFeatures.AuthenticationFeatures.Queries.GetUserRolesByUserIdAndCompanyId;
public sealed record GetUserRolesByUserIdAndCompanyIdQueryResponse(
    List<string> Roles)
    ;

using E_Accounting.Application.Messaging;
using E_Accounting.Application.Services.AuthenticationServices;
using E_Accounting.Application.Services.MasterService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Application.Features.MasterFeatures.AuthenticationFeatures.Queries.GetUserRolesByUserIdAndCompanyId;
    internal class GetUserRolesByUserIdAndCompanyIdQueryHandler : IQueryHandler<GetUserRolesByUserIdAndCompanyIdQuery, GetUserRolesByUserIdAndCompanyIdQueryResponse>
{
    private readonly IAuthenticationService _authService;

    public GetUserRolesByUserIdAndCompanyIdQueryHandler(IAuthenticationService authService)
    {
        _authService = authService;
    }

    public async Task<GetUserRolesByUserIdAndCompanyIdQueryResponse> Handle(GetUserRolesByUserIdAndCompanyIdQuery request, CancellationToken cancellationToken)
    {
        List<string> roles = await _authService.GetRolesByUserIdAndCompanyId(request.UserId, request.CompanyId, cancellationToken);

        return new(roles);
    }
}
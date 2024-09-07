using E_Accounting.Application.Messaging;
using E_Accounting.Application.Services.MasterService;

namespace E_Accounting.Application.Features.MasterFeatures.MainRoleFeatures.Queries.GetAllMainRoleQuery
{
    public sealed class GetAllMainRolesQueryHandler : IQueryHandler<GetAllMainRolesQuery, GetAllMainRolesQueryResponse>
    {
        public readonly IMainRoleService _mainRoleService;
        public GetAllMainRolesQueryHandler(IMainRoleService mainRoleService)
        {
            _mainRoleService = mainRoleService;
        }

        public async Task<GetAllMainRolesQueryResponse> Handle(GetAllMainRolesQuery request, CancellationToken cancellationToken)
        {
            var result = _mainRoleService.GetAll().ToList();
            return new(result);
        }
    }
}

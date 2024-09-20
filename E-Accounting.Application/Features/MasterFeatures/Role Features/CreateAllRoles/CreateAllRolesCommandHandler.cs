using E_Accounting.Application.Features.Role_Features;
using E_Accounting.Application.Messaging;
using E_Accounting.Application.Services.MasterService;
using E_Accounting.Domain.Entities.App_Entites.Identity;
using E_Accounting.Domain.Roles;
using MediatR;

namespace E_Accounting.Application.Features.CompanyFeatures.Role_Features.CreateAllRoles
{
    public sealed class CreateAllRolesHandler : ICommandHandler<CreateAllRolesCommand, CreateAllRolesCommandResponse>
    {
        private readonly IRoleService _roleService;
        public CreateAllRolesHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

         async Task<CreateAllRolesCommandResponse> IRequestHandler<CreateAllRolesCommand, CreateAllRolesCommandResponse>.Handle(CreateAllRolesCommand request, CancellationToken cancellationToken)
        {
            IList<AppRole> OriginalRoleList = RoleList.GetStaticRoles();
            IList<AppRole> currentRoleList = new List<AppRole>();

            foreach (AppRole role in OriginalRoleList)
            {
                AppRole checkRole = await _roleService.GetByUCAFCode(role.Code);
                if (checkRole == null)
                    currentRoleList.Add(role);
            }

            await _roleService.AddRangeAsync(currentRoleList);
            return new CreateAllRolesCommandResponse();
        }
    }

}

using E_Accounting.Application.Messaging;
using E_Accounting.Application.Services.MasterService;
using E_Accounting.Domain.Entities.App_Entites;
using E_Accounting.Domain.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Application.Features.MasterFeatures.MainRoleFeatures.Commands.CreateStaticRoles
{
    public sealed class CreateStaticMainRolesCommandHandler : ICommandHandler<CreateStaticMainRolesCommand, CreateStaticMainRolesCommandResponse>
    {
        private readonly IMainRoleService _roleService;
        public CreateStaticMainRolesCommandHandler(IMainRoleService roleService)
        {
            _roleService = roleService;
        }
        public async Task<CreateStaticMainRolesCommandResponse> Handle(CreateStaticMainRolesCommand request, CancellationToken cancellationToken)
        {
            List<MainRole> mainRoles = RoleList.GetStaticMainRoles();
            List<MainRole> newMainRoles = new List<MainRole>();

            foreach (var role in mainRoles)
            {
                MainRole checkMainRole = await _roleService.GetByTitleAndCompanyId(role.Title, role.CompanyId, cancellationToken);

                if (checkMainRole == null)
                {
                    newMainRoles.Add(role);
                }
            }

            await _roleService.CreateRangeAsync(newMainRoles, cancellationToken);

            return new();
        }
    }
}

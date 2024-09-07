using E_Accounting.Application.Messaging;
using E_Accounting.Domain.Entities.App_Entites;

namespace E_Accounting.Application.Features.MasterFeatures.MainRoleFeatures.Commands.CreateStaticRoles;

    public sealed record CreateStaticMainRolesCommand
        (
        List<MainRole> MainRoles
        ) : ICommand<CreateStaticMainRolesCommandResponse>;


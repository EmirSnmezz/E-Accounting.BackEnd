using E_Accounting.Application.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace E_Accounting.Application.Features.MasterFeatures.MainRoleAndRoleRelationShipFeatures.Commands.Create
{
    public sealed record CreateMainRoleAndRoleRelationShipCommand
        (
            string RoleId,
          string MainRoleId
        ) : ICommand<CreateMainRoleAndRoleRelationShipsCommandResponse>;
}

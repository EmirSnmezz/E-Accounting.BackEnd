using E_Accounting.Application.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Application.Features.MasterFeatures.MainRoleFeatures.Commands.CreateRole
{
    public sealed record CreateMainRoleCommand(
            string Title,
            string CompanyId = null) : ICommand<CreateMainRoleCommandResponse>;
}

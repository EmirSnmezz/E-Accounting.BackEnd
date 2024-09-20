using E_Accounting.Application.Messaging;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace E_Accounting.Application.Features.Role_Features.Commands.UpdateRole
{
    public record UpdateRoleCommand
        (
            string Name,
            string Id,
            string Code
        ) : ICommand<UpdateRoleCommandResponse>;
}

using E_Accounting.Application.Messaging;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace E_Accounting.Application.Features.Role_Features.Commands.RemoveRole
{
    public record RemoveRoleCommand
        (
            string Id
        ): ICommand<RemoveRoleCommandResponse>;
}

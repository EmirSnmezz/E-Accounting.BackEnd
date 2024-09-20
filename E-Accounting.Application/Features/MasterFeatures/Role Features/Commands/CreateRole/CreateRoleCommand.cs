using E_Accounting.Application.Messaging;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace E_Accounting.Application.Features.Role_Features
{
    public record CreateRoleCommand
        (
            string Code,
            string Name,
            string Title
        ) : ICommand<CreateRoleCommandResponse>;
}

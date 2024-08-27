
using E_Accounting.Application.Messaging;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace E_Accounting.Application.Features.Company_Features.UCAFFeautres.Commands.CreateUCAF
{
    public record CreateUCAFCommand
        (
            string CompanyId,
            string Name,
            string Type,
            string Code
        )  : ICommand<CreateUCAFCommandResponse>;
}

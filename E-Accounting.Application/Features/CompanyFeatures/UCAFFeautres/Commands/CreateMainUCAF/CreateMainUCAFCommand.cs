using E_Accounting.Application.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace E_Accounting.Application.Features.CompanyFeatures.UCAFFeautres.Commands.CreateMainUCAF
{
    public sealed record CreateMainUCAFCommand(string companyId) : ICommand<CreateMainUCAFCommandResponse>
    {
        public static implicit operator CreateMainUCAFCommand(CreateMainUCAFCommandResponse v)
        {
            throw new NotImplementedException();
        }
    }
}

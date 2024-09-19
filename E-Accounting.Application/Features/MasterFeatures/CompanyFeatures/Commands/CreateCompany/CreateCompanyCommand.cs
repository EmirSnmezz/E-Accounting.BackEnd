using E_Accounting.Application.Messaging;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace E_Accounting.Application.Features.MasterFeatures.CompanyFeatures.Commands.CreateCompany
{
    public record CreateCompanyCommand 
        (
        string Name,
        string ServerName,
        string DatabaseName,
        string ServerUserId,
        string ServerPassword
        ) : ICommand<CreateCompanyCommandResponse>;
}

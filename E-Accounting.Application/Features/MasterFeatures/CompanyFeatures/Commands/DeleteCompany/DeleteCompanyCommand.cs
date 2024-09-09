using E_Accounting.Application.Messaging;
using System.Windows.Input;

namespace E_Accounting.Application.Features.MasterFeatures.CompanyFeatures.Commands.DeleteCompany;
public sealed record DeleteCompanyCommand
    (
        string Id
    ) : ICommand<DeleteCompanyCommandResponse>;

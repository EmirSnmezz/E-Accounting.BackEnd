using E_Accounting.Application.Messaging;

namespace E_Accounting.Application.Features.MasterFeatures.CompanyFeatures.Commands.UpdateCompany;
public sealed record UpdateCompanyCommand
    (
        string Id,
        string Name,
        string ServerName,
        string DatabaseName,
        string UserId,
        string Password
    ) : ICommand<UpdateCompanyCommandResponse>;

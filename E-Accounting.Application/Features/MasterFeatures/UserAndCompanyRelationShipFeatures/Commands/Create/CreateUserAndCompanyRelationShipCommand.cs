using E_Accounting.Application.Messaging;

namespace E_Accounting.Application.Features.MasterFeatures.UserAndCompanyRelationShipFeatures.Commands.Create;
public sealed record CreateUserAndCompanyRelationShipCommand
    (
        string userId,
        string companyId
    ) : ICommand<CreateUserAndCompanyRelationShipCommandResponse>;
  

using E_Accounting.Application.Messaging;

namespace E_Accounting.Application.Features.MasterFeatures.UserAndCompanyRelationShipFeatures.Commands.Remove;
public sealed record RemoveUserAndCompanyRelationShipCommand(
            string Id
        ) : ICommand<RemoveUserAndCompanyRelationShipCommandResponse>;
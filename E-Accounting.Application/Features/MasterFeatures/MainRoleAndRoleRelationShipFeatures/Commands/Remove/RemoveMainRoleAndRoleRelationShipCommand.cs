using E_Accounting.Application.Messaging;

namespace E_Accounting.Application.Features.MasterFeatures.MainRoleAndRoleRelationShipFeatures.Commands.Remove;
public sealed record RemoveMainRoleAndRoleRelationShipCommand
    (
        string Id
    ) : ICommand<RemoveMainRoleAndRoleRelationShipCommandResponse>;

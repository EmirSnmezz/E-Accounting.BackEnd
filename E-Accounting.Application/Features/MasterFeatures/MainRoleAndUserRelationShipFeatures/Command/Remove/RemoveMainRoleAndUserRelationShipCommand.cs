using E_Accounting.Application.Messaging;

namespace E_Accounting.Application.Features.MasterFeatures.MainRoleAndUserRelationShipFeatures.Command.Remove;
public sealed record RemoveMainRoleAndUserRelationShipCommand
    (
        string Id
    ) : ICommand<RemoveMainRoleAndUserRelationShipCommandResponse>
{
}


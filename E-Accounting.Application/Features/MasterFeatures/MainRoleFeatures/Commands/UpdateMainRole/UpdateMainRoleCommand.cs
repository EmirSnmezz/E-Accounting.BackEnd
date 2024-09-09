using E_Accounting.Application.Messaging;
using System.Windows.Input;

namespace E_Accounting.Application.Features.MasterFeatures.MainRoleFeatures.Commands.UpdateMainRole;
public sealed record UpdateMainRoleCommand
    (
        string Id,
        string Title
    ) : ICommand<UpdateMainRoleCommandResponse>;

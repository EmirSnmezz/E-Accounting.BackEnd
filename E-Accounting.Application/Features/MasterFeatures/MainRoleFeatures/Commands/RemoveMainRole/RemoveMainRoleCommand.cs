using E_Accounting.Application.Messaging;
using System.Windows.Input;

namespace E_Accounting.Application.Features.MasterFeatures.MainRoleFeatures.Commands.RemoveMainRole;
public sealed record RemoveMainRoleCommand
    (
        string Id
    ) : ICommand<RemoveMainRoleCommandResponse>;
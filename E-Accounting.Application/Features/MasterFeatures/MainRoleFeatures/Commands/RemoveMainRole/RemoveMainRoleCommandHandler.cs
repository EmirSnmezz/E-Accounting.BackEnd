using E_Accounting.Application.Messaging;
using E_Accounting.Application.Services.MasterService;

namespace E_Accounting.Application.Features.MasterFeatures.MainRoleFeatures.Commands.RemoveMainRole;
public class RemoveMainRoleCommandHandler : ICommandHandler<RemoveMainRoleCommand, RemoveMainRoleCommandResponse>
{
    private readonly IMainRoleService _mainRoleService;

    public RemoveMainRoleCommandHandler(IMainRoleService mainRoleService)
    {
        _mainRoleService = mainRoleService;
    }

    public async Task<RemoveMainRoleCommandResponse> Handle(RemoveMainRoleCommand request, CancellationToken cancellationToken)
    {
        await _mainRoleService.RemoveById(request.Id, cancellationToken);
        return new();
    }
}
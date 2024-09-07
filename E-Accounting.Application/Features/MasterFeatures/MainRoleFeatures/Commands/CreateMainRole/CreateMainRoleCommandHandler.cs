using E_Accounting.Application.Features.MasterFeatures.MainRoleFeatures.Commands.CreateRole;
using E_Accounting.Application.Messaging;
using E_Accounting.Application.Services.MasterService;
using E_Accounting.Application.UnitOfWorks;
using E_Accounting.Domain.Entities.App_Entites;

namespace E_Accounting.Application.Features.MasterFeatures.MainRoleFeatures.Commands.CreateMainRole;
public sealed class CreateMainRoleCommandHandler : ICommandHandler<CreateMainRoleCommand, CreateMainRoleCommandResponse>
{
    private readonly IMainRoleService _mainRoleService;

    public CreateMainRoleCommandHandler(IMainRoleService mainRoleService)
    {
        _mainRoleService = mainRoleService;
    }

    public async Task<CreateMainRoleCommandResponse> Handle(CreateMainRoleCommand request, CancellationToken cancellationToken)
    {
        MainRole checkMainRoleTitle = await _mainRoleService.GetByTitleAndCompanyId(request.Title, request.CompanyId, cancellationToken);
        if (checkMainRoleTitle != null)
        {
            throw new Exception("Bu Role Daha Önce Kaydedilmiş");
        }

        MainRole mainRole = new(
                                 Guid.NewGuid().ToString(),
                                 request.Title,
                                 request.IsRoleCreatedByAdmin,
                                 request.CompanyId );

        await _mainRoleService.CreateAsync(mainRole, cancellationToken);
        return new();
    }
}


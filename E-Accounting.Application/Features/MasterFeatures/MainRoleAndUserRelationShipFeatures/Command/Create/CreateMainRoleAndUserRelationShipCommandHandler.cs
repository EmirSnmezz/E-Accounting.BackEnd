using E_Accounting.Application.Messaging;
using E_Accounting.Application.Services.MainRoleAndUserRelationShipService;
using E_Accounting.Domain.Entities.App_Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Application.Features.MasterFeatures.MainRoleAndUserRelationShipFeatures.Command.Create;

public sealed record CreateMainRoleAndUserRelationShipCommandHandler : ICommandHandler<CreateMainRoleAndUserRelationShipCommand, CreateMainRoleAndUserRelationShipCommandResponse>
{
    private readonly IMainRoleAndUserRelationShipService _service;
    public CreateMainRoleAndUserRelationShipCommandHandler(IMainRoleAndUserRelationShipService service)
    {
        _service = service;
    }
    public async Task<CreateMainRoleAndUserRelationShipCommandResponse> Handle(CreateMainRoleAndUserRelationShipCommand request, CancellationToken cancellationToken)
    {
        MainRoleAndUserRelationShip checkMainRoleAndUserRelationShip = await _service.GetByUserIdCompanyIdAndMainRoleId(userId: request.userId, companyId: request.companyId, mainRoleId: request.mainRoleId, cancellationToken);

        if (checkMainRoleAndUserRelationShip != null)
        {
            throw new Exception("Kullanıcı Role İlişkisi Daha Önceden Tanımlanmış");
        }

        MainRoleAndUserRelationShip mainRoleAndUserRelationShip = new(Id: Guid.NewGuid().ToString(), userId: request.userId, mainRoleId: request.mainRoleId, companyId: request.companyId);

        await _service.CreateAsync(mainRoleAndUserRelationShip, cancellationToken);

        return new();
    }
}


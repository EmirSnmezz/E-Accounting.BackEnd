using E_Accounting.Application.Messaging;
using E_Accounting.Application.Services.MainRoleAndUserRelationShipService;
using E_Accounting.Domain.Entities.App_Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Application.Features.MasterFeatures.MainRoleAndUserRelationShipFeatures.Command.Remove;
public sealed record RemoveMainRoleAndUserRelationShipCommandHandler : ICommandHandler<RemoveMainRoleAndUserRelationShipCommand, RemoveMainRoleAndUserRelationShipCommandResponse>
{
    private readonly IMainRoleAndUserRelationShipService _service;

    public RemoveMainRoleAndUserRelationShipCommandHandler(IMainRoleAndUserRelationShipService service)
    {
        _service = service;
    }

    public async Task<RemoveMainRoleAndUserRelationShipCommandResponse> Handle(RemoveMainRoleAndUserRelationShipCommand request, CancellationToken cancellationToken)
    {
        MainRoleAndUserRelationShip deletedEntity = await _service.GetById(request.Id);

        if (deletedEntity == null)
        {
            throw new Exception("Silinmek İstenen MainRole/Kullanıcı İlişkisi Bulunamadı");
        }

        await _service.RemoveById(request.Id);

        return new();
    }
}

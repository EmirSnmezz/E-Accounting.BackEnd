using E_Accounting.Application.Messaging;
using E_Accounting.Application.Services.MainRoleAndRoleRelationShipService;
using E_Accounting.Application.Services.MainRoleAndUserRelationShipService;
using E_Accounting.Domain.Entities.App_Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Application.Features.MasterFeatures.MainRoleAndRoleRelationShipFeatures.Commands.Update;
public sealed record UpdateMainRoleAndRoleRelationShipCommandHandler : ICommandHandler<UpdateMainRoleAndRoleRelationShipCommand, UpdateMainRoleAndRoleRelationShipCommandResponse>
{
    private readonly IMainRoleAndRoleRelationShipService _service;

    public UpdateMainRoleAndRoleRelationShipCommandHandler(IMainRoleAndRoleRelationShipService service)
    {
        _service = service;
    }

    public async Task<UpdateMainRoleAndRoleRelationShipCommandResponse> Handle(UpdateMainRoleAndRoleRelationShipCommand request, CancellationToken cancellationToken)
    {
        MainRoleAndRoleRelationship entity = await _service.GetByIdAsnyc(request.Id, cancellationToken);

        if (entity == null)
        {
            throw new Exception("Güncellenmek İstenen İlişki Kaydına Erişilemedi");
        }

        if (entity.RoleId == request.RoleId && entity.MainRoleId == request.MainRoleId)
        {
            throw new Exception("Bu İlişki Daha Önce Kurulmuş");
        }

        entity.RoleId = request.RoleId;
        entity.MainRoleId = request.MainRoleId;

        await _service.UpdateAsync(entity, cancellationToken);

        return new();
    }
}


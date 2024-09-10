using E_Accounting.Application.Messaging;
using E_Accounting.Application.Services.MainRoleAndRoleRelationShipService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Application.Features.MasterFeatures.MainRoleAndRoleRelationShipFeatures.Commands.Remove;

public sealed record RemoveMainRoleAndRoleRelationShipCommandHandler : ICommandHandler<RemoveMainRoleAndRoleRelationShipCommand, RemoveMainRoleAndRoleRelationShipCommandResponse>
{
    private readonly IMainRoleAndRoleRelationShipService _service;

    public RemoveMainRoleAndRoleRelationShipCommandHandler(IMainRoleAndRoleRelationShipService service)
    {
        _service = service;
    }

    public async Task<RemoveMainRoleAndRoleRelationShipCommandResponse> Handle(RemoveMainRoleAndRoleRelationShipCommand request, CancellationToken cancellationToken)
    {
        var entity = await _service.GetByIdAsnyc(request.Id, cancellationToken);

        if (entity == null)
        {
            throw new Exception("Silinmek İstenen İlişki Kaydına Erişilemedi");
        }
         await _service.RemoveById(request.Id, cancellationToken);

        return new();
    }
}


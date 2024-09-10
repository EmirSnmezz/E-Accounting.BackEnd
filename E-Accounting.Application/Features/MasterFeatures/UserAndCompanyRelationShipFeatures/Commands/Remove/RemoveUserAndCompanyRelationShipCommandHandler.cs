using E_Accounting.Application.Messaging;
using E_Accounting.Application.Services.UserAndCompanyRelationShipService;
using E_Accounting.Domain.Entities.App_Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Application.Features.MasterFeatures.UserAndCompanyRelationShipFeatures.Commands.Remove;
public sealed record RemoveUserAndCompanyRelationShipCommandHandler : ICommandHandler<RemoveUserAndCompanyRelationShipCommand, RemoveUserAndCompanyRelationShipCommandResponse>
{
    private readonly IUserAndCompanyRelationShipService _service;

    public RemoveUserAndCompanyRelationShipCommandHandler(IUserAndCompanyRelationShipService service)
    {
        _service = service;
    }

    public async Task<RemoveUserAndCompanyRelationShipCommandResponse> Handle(RemoveUserAndCompanyRelationShipCommand request, CancellationToken cancellationToken)
    {
        UserAndCompanyRelationShip deletedEntity = await _service.GetByIdAsync(request.Id, cancellationToken);

        if (deletedEntity == null)
        {
            throw new Exception("Şirket/Kişi ilişkisi bulunamadı.");
        }

        await _service.RemoveByIdAsync(request.Id, cancellationToken);

        return new();
    }
}


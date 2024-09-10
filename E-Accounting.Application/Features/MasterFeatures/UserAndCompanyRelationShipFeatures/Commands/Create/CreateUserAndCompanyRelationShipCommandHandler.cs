using E_Accounting.Application.Messaging;
using E_Accounting.Application.Services.UserAndCompanyRelationShipService;
using E_Accounting.Domain.Entities.App_Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Application.Features.MasterFeatures.UserAndCompanyRelationShipFeatures.Commands.Create;

    public sealed record CreateUserAndCompanyRelationShipCommandHandler : ICommandHandler<CreateUserAndCompanyRelationShipCommand, CreateUserAndCompanyRelationShipCommandResponse>
    {
        private readonly IUserAndCompanyRelationShipService _service;
        public CreateUserAndCompanyRelationShipCommandHandler(IUserAndCompanyRelationShipService service)
        {
            _service = service;
        }

    public async Task<CreateUserAndCompanyRelationShipCommandResponse> Handle(CreateUserAndCompanyRelationShipCommand request, CancellationToken cancellationToken)
    {
        UserAndCompanyRelationShip UserAndCompanyRelationShipIsRelated = await _service.GetByUserIdAndCompanyId(userId: request.userId, companyId: request.companyId, cancellationToken);

        if (UserAndCompanyRelationShipIsRelated != null)
        {
            throw new Exception("Kullanıcı Daha Önce Şirketle İlişkilendirilmiş");
        }

        UserAndCompanyRelationShip userAndCompanyRelationShip = new(
            Id: Guid.NewGuid().ToString(),
            masterUserId: request.userId,
            companyId: request.companyId
            );

        await _service.CreateAsync(userAndCompanyRelationShip, cancellationToken);

        return new();

    }
}


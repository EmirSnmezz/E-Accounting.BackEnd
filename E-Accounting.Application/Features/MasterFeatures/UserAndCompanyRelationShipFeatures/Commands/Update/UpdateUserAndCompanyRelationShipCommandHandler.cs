using E_Accounting.Application.Messaging;
using E_Accounting.Application.Services.UserAndCompanyRelationShipService;
using E_Accounting.Domain.Entities.App_Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace E_Accounting.Application.Features.MasterFeatures.UserAndCompanyRelationShipFeatures.Commands.Update;
    public sealed record UpdateUserAndCompanyRelationShipCommandHandler : ICommandHandler<UpdateUserAndCompanyRelationShipCommand, UpdateUserAndCompanyRelationShipCommandResponse>
    {
        private readonly IUserAndCompanyRelationShipService _service;

        public UpdateUserAndCompanyRelationShipCommandHandler(IUserAndCompanyRelationShipService service)
        {
            _service = service;
        }

    public async Task<UpdateUserAndCompanyRelationShipCommandResponse> Handle(UpdateUserAndCompanyRelationShipCommand request, CancellationToken cancellationToken)
    {
        UserAndCompanyRelationShip checkIsThereEntity = await _service.GetByUserIdAndCompanyId(request.userId, request.companyId, cancellationToken);

        if (checkIsThereEntity != null)
        {
            throw new Exception("Bu Şirket-Kullanıcı İlişkisi Zaten Mevcut");
        }

        UserAndCompanyRelationShip updatedEntity = await _service.GetByIdAsync(request.Id, cancellationToken);

        if (updatedEntity == null)
        {
            throw new Exception("Şirket/Kullanıcı ilişkisi bulunamadı");
        }

        updatedEntity.MasterUserId = request.userId;
        updatedEntity.CompanyId = request.companyId;

        await _service.UpdateAsync(updatedEntity, cancellationToken);

        return new();
        
    }
}


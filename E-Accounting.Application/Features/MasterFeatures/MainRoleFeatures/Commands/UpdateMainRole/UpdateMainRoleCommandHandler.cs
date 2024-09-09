using E_Accounting.Application.Messaging;
using E_Accounting.Application.Services.MasterService;
using E_Accounting.Domain.Entities.App_Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Application.Features.MasterFeatures.MainRoleFeatures.Commands.UpdateMainRole
{
    public class UpdateMainRoleCommandHandler : ICommandHandler<UpdateMainRoleCommand, UpdateMainRoleCommandResponse>
    {
        private readonly IMainRoleService _mainRoleService;

        public UpdateMainRoleCommandHandler(IMainRoleService mainRoleService)
        {
            _mainRoleService = mainRoleService;
        }

        public async Task<UpdateMainRoleCommandResponse> Handle(UpdateMainRoleCommand request, CancellationToken cancellationToken)
        {
            MainRole mainRole = await _mainRoleService.GetByIdAsync(request.Id, cancellationToken);
            if (mainRole == null)
            {
                throw new Exception("Güncellenmek istenen MainRole Bulunamadı");
            }

            if (mainRole.Title == request.Title)
            {
                throw new Exception("Güncellemeye çalıştığınız MainRole adı eski adıyla aynı");
            }

            if (mainRole.Title != request.Title)
            {
                MainRole checkMainRoleTitle = await _mainRoleService.GetByTitleAndCompanyId(request.Title, mainRole.CompanyId, cancellationToken);

                if (checkMainRoleTitle != null)
                {
                    throw new Exception("Bu rol adı daha önce kullanılmış");
                }
            }

            mainRole.Title = request.Title;
            await _mainRoleService.UpdateAsync(mainRole, cancellationToken);
            return new();

        }
    }
}

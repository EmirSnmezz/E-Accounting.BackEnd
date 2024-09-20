using E_Accounting.Application.Services.MasterService;
using E_Accounting.Domain.Entities.App_Entites.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Application.Features.Role_Features.Commands.RemoveRole
{
    public sealed class RemoveRoleCommandHandler : IRequestHandler<RemoveRoleCommand, RemoveRoleCommandResponse>
    {
        private readonly IRoleService _roleManager;

        public RemoveRoleCommandHandler(IRoleService roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<RemoveRoleCommandResponse> Handle(RemoveRoleCommand request, CancellationToken cancellationToken)
        {
            AppRole role = _roleManager.GetByIdAsync(request.Id).Result;

            if (role == null)
            {
                throw new Exception("İlgili Rol Kaydı Bulunamadı");
            }

            await _roleManager.DeleteAsync(role);

            return new RemoveRoleCommandResponse(); 
        }
    }
}

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
    public sealed class RemoveRoleHandler : IRequestHandler<RemoveRoleRequest, RemoveRoleResponse>
    {
        private readonly RoleManager<AppRole> _roleManager;

        public RemoveRoleHandler(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<RemoveRoleResponse> Handle(RemoveRoleRequest request, CancellationToken cancellationToken)
        {
            AppRole role = await _roleManager.FindByIdAsync(request.Id);

            if (role == null)
            {
                throw new Exception("İlgili Rol Kaydı Bulunamadı");
            }

            _roleManager.DeleteAsync(role);

            return new RemoveRoleResponse(); 
        }
    }
}

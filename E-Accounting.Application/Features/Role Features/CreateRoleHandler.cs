using E_Accounting.Domain.Entities.App_Entites.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Application.Features.Role_Features
{
    public class CreateRoleHandler : IRequestHandler<CreateRoleRequest, CreateRoleResponse>
    {
        private readonly RoleManager<AppRole> _roleManager;

        public CreateRoleHandler(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;    
        }


        public async Task<CreateRoleResponse> Handle(CreateRoleRequest request, CancellationToken cancellationToken)
        {
            AppRole role = await _roleManager.FindByIdAsync(request.Name);

            if (role != null)
            {
                throw new Exception("Bu rol daha önce eklenmiş");
            }

            role = new AppRole
            {
                Id = Guid.NewGuid().ToString(),
                Name = request.Name,
            };

            await _roleManager.CreateAsync(role);
            return new CreateRoleResponse();
        }
    }
}

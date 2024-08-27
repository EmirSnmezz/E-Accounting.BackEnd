using E_Accounting.Application.Services.MasterService;
using E_Accounting.Domain.Entities.App_Entites.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Application.Features.Role_Features.Queries.GetAllRoles
{
    public sealed class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQuery, GetAllRolesQueryResponse>
    {
        private readonly IRoleService _roleManager;
        public GetAllRolesQueryHandler(IRoleService roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<GetAllRolesQueryResponse> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            IQueryable<AppRole> roles = await _roleManager.GettAllRolesAsync();

            if (!roles.Any())
            {
                throw new Exception("Görüntülenecek Rol Kaydı Bulunamadı");
            }

            return new  GetAllRolesQueryResponse();

        }
    }
}

using AutoMapper;
using E_Accounting.Application.Features.Role_Features;
using E_Accounting.Application.Features.Role_Features.Commands.RemoveRole;
using E_Accounting.Application.Features.Role_Features.Commands.UpdateRole;
using E_Accounting.Application.Services.MasterService;
using E_Accounting.Domain.Entities.App_Entites.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Persistance.Service.Role_Service
{
    public sealed class RoleService : IRoleService
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IMapper _mapper;
        public RoleService(RoleManager<AppRole> roleManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task AddAsync(CreateRoleCommand request)
        {
            AppRole role = _mapper.Map<AppRole>(request);
            role.Id = Guid.NewGuid().ToString();
            await _roleManager.CreateAsync(role);
        }

        public async Task DeleteAsync(AppRole role)
        {
            await _roleManager.DeleteAsync(role);
        }

        public async Task UpdateAsync(AppRole role)
        {    
            await _roleManager.UpdateAsync(role);
        }
        public async Task<IQueryable<AppRole>> GettAllRolesAsync()
        {
            IList<AppRole> roles = await _roleManager.Roles.ToListAsync();
            return roles.AsQueryable<AppRole>();
        }

        public async Task<AppRole> GetByIdAsync(string id)
        {
            AppRole role = await _roleManager.FindByIdAsync(id);
            return role;
        }

        public async Task<AppRole> GetByUCAFCode(string UCAFCode)
        {
            AppRole role = await _roleManager.FindByIdAsync(UCAFCode);
            return role;
        }
    }
}

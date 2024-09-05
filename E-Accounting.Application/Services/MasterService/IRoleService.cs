using E_Accounting.Application.Features.Role_Features;
using E_Accounting.Application.Features.Role_Features.Commands.RemoveRole;
using E_Accounting.Application.Features.Role_Features.Commands.UpdateRole;
using E_Accounting.Domain.Entities.App_Entites.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Application.Services.MasterService
{
    public interface IRoleService
    {
        Task AddAsync(CreateRoleCommand request);
        Task AddRangeAsync(IEnumerable<AppRole> roles);
        Task UpdateAsync(AppRole role);
        Task DeleteAsync(AppRole role);
        Task<IQueryable<AppRole>> GettAllRolesAsync();
        Task<AppRole> GetByIdAsync(string id);
        Task<AppRole> GetByUCAFCode(string UCAFCode);

    }
}

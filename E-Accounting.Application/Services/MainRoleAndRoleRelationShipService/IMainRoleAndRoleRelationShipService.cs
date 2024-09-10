using E_Accounting.Domain.Entities.App_Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Application.Services.MainRoleAndRoleRelationShipService
{
    public interface IMainRoleAndRoleRelationShipService
    {
        Task CreateAsync(MainRoleAndRoleRelationship mainRoleAndRoleRelationship, CancellationToken cancellationToken);
        Task UpdateAsync(MainRoleAndRoleRelationship mainRoleAndRoleRelationship, CancellationToken cancellationToken);
        Task RemoveById (string id, CancellationToken cancellationToken);
        IQueryable<MainRoleAndRoleRelationship> GetAll();
        Task<MainRoleAndRoleRelationship> GetByIdAsnyc(string id, CancellationToken cancellationToken);
        Task<MainRoleAndRoleRelationship> GetByRoleIdAndMainRoleId(string roleId, string mainRoleId, CancellationToken cancellationToken);
    }
}

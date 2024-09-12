using E_Accounting.Domain.Entities.App_Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Application.Services.UserAndCompanyRelationShipService
{
    public interface IUserAndCompanyRelationShipService
    {
        Task CreateAsync(UserAndCompanyRelationShip userAndCompanyRelationShip, CancellationToken cancellationToken);
        Task UpdateAsync(UserAndCompanyRelationShip userAndCompanyRelationShip, CancellationToken cancellationToken1);
        Task RemoveByIdAsync(string id, CancellationToken cancellationToken);
        Task<UserAndCompanyRelationShip> GetByIdAsync(string id, CancellationToken cancellationToken);
        Task<UserAndCompanyRelationShip> GetByUserIdAndCompanyId(string userId, string companyId, CancellationToken cancellationToken);
        Task<IList<UserAndCompanyRelationShip>> GetCompanyListByUserId(string userId, CancellationToken cancellationToken);
    }
}

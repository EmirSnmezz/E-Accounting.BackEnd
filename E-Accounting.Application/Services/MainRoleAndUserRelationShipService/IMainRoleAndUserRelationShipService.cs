using E_Accounting.Domain.Entities.App_Entites;

namespace E_Accounting.Application.Services.MainRoleAndUserRelationShipService
{
    public interface IMainRoleAndUserRelationShipService
    {
        Task CreateAsync(MainRoleAndUserRelationShip mainRoleAndUserRelationShip, CancellationToken cancellationToken);
        Task  RemoveById(string id);
        Task <MainRoleAndUserRelationShip> GetByUserIdCompanyIdAndMainRoleId(string userId, string companyId, string mainRoleId, CancellationToken cancellation = default);
        Task <MainRoleAndUserRelationShip> GetById(string id);
    }
}

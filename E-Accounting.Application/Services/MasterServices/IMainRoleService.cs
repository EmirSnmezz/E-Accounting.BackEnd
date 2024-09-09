using E_Accounting.Domain.Entities.App_Entites;

namespace E_Accounting.Application.Services.MasterService;

public interface IMainRoleService
{
    public Task<MainRole> GetByTitleAndCompanyId(string title, string companyId, CancellationToken cancellationToken);
    Task CreateAsync(MainRole mainRole, CancellationToken cancellationToken);
    Task CreateRangeAsync(List<MainRole> mainRoles, CancellationToken cancellationToken);
    IList<MainRole> GetAll();
    Task UpdateAsync (MainRole mainRole, CancellationToken cancellationToken);
    Task RemoveById (string id, CancellationToken cancellationToken);
    Task <MainRole> GetByIdAsync(string id, CancellationToken cancellationToken);
}


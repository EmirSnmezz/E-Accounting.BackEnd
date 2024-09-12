using E_Accounting.Domain.Entities.App_Entites;

namespace E_Accounting.Application.Services.AuthenticationServices;
public interface IAuthenticationService
{
    Task<AppUser> GetByEmailOrUserNameAsync(string emailOrUserName);
    Task<bool> CheckPasswordAsync(AppUser user, string password);
    Task<List<UserAndCompanyRelationShip>> GetCompanyListByUserIdAsync(string userId, CancellationToken cancellationToken);
    Task<List<string>> GetRolesByUserIdAndCompanyId(string userId, string companyId, CancellationToken cancellationToken);   
}
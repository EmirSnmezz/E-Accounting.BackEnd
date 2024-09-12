using E_Accounting.Application.Services.AuthenticationServices;
using E_Accounting.Application.Services.MainRoleAndRoleRelationShipService;
using E_Accounting.Application.Services.MainRoleAndUserRelationShipService;
using E_Accounting.Application.Services.UserAndCompanyRelationShipService;
using E_Accounting.Domain.Entities.App_Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace E_Accounting.Persistance.Service.MasterDbServices.AuthenticationService;

public sealed class AuthenticationService : IAuthenticationService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IUserAndCompanyRelationShipService _userAndCompanyRelationShipService;
    private readonly IMainRoleAndUserRelationShipService _mainRoleAndUserRelationShipService;
    private readonly IMainRoleAndRoleRelationShipService _mainRoleService;
    public AuthenticationService(UserManager<AppUser> userManager, IUserAndCompanyRelationShipService userAndCompanyRelationShipService, IMainRoleAndUserRelationShipService mainRoleAndUserRelationShipService, IMainRoleAndRoleRelationShipService mainRoleService)
    {
        _userManager = userManager;
        _userAndCompanyRelationShipService = userAndCompanyRelationShipService;
        _mainRoleAndUserRelationShipService = mainRoleAndUserRelationShipService;
        _mainRoleService = mainRoleService;
    }

    public async Task<bool> CheckPasswordAsync(AppUser user, string password)
    {
        return await _userManager.CheckPasswordAsync(user, password);
    }

    public async Task<AppUser> GetByEmailOrUserNameAsync(string emailOrUserName)
    {
        return await _userManager.Users.Where(x => x.Email == emailOrUserName || x.UserName == emailOrUserName).FirstOrDefaultAsync();
    }

    public async Task<List<UserAndCompanyRelationShip>> GetCompanyListByUserIdAsync(string userId, CancellationToken cancellationToken)
    {
        var result = await _userAndCompanyRelationShipService.GetCompanyListByUserId(userId, cancellationToken);
        return result.ToList();
    }

    public async Task<List<string>> GetRolesByUserIdAndCompanyId(string userId, string companyId, CancellationToken cancellationToken)
    {
        MainRoleAndUserRelationShip mainRoleAndUserRelationShip = await _mainRoleAndUserRelationShipService.GetRolesByUserIdAndCompanyId(userId, companyId, cancellationToken);

        if (mainRoleAndUserRelationShip.CompanyId != companyId || mainRoleAndUserRelationShip.UserId != userId)
        {
            throw new Exception("Bu şirkete tanımlı böyle bir kullanıcı kaydı yok.");
        }

        List<MainRoleAndRoleRelationship> getMainRoles = await _mainRoleService.GetListByIdForGetRolesAsync(mainRoleAndUserRelationShip.MainRoleId, cancellationToken);

        if (getMainRoles == null || getMainRoles.Count == 0)
        {
            throw new Exception("İlgili Kullanıcıya Ait Role Ataması Gerçekleştirilmemiş");
        }

        List<string> roles = getMainRoles.Select(s => s.AppRole.Code).ToList();

        return roles;
    }
}
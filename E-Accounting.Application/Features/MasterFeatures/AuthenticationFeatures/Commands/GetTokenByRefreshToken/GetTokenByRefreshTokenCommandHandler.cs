using E_Accounting.Application.Abstraction.JWT;
using E_Accounting.Application.Messaging;
using E_Accounting.Application.Services.AuthenticationServices;
using E_Accounting.Domain.DTOs;
using E_Accounting.Domain.Entities.App_Entites;
using Microsoft.AspNetCore.Identity;

namespace E_Accounting.Application.Features.MasterFeatures.AuthenticationFeatures.Commands.GetTokenByRefreshToken;
public sealed record GetTokenByRefreshTokenCommandHandler : ICommandHandler<GetTokenByRefreshTokenCommand, GetTokenByRefreshTokenCommandResponse>
{
    private readonly IJwtProvider _jwtProvider;
    private readonly UserManager<AppUser> _userManager;
    private readonly IAuthenticationService _authenticationService;

    public GetTokenByRefreshTokenCommandHandler(IJwtProvider jwtProvider, UserManager<AppUser> userManager, IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
        _jwtProvider = jwtProvider;
        _userManager = userManager;
    }
    public async Task<GetTokenByRefreshTokenCommandResponse> Handle(GetTokenByRefreshTokenCommand request, CancellationToken cancellationToken)
    {
        AppUser user = await _userManager.FindByIdAsync(request.UserId);

        if (user == null)
        {
            throw new Exception("Kullancı Bulunamadı");
        }

        if (user.RefreshToken != request.RefreshToken)
        {
            throw new Exception("Refresh Token Geçerli Değil");
        }

        IList<UserAndCompanyRelationShip> companies = await _authenticationService.GetCompanyListByUserIdAsync(user.Id, cancellationToken);
        IList<CompanyDto> compainesDto = companies.Select(x => new CompanyDto(x.CompanyId, x.Company.Name)).ToList();

        if (companies.Count == 0)
        {
            throw new Exception("Herhangi bir şirkette kayıtlı değilsiniz");
        }

        GetTokenByRefreshTokenCommandResponse response = new(
            Token: await _jwtProvider.CreateTokenAsync(user),
            Email: user.Email,
            UserId: user.Id,
            FirstAndLastName: user.UserFirstAndLastName,
            Companies: compainesDto,
            Company: compainesDto[0],
            Year: DateTime.Now.Year);

        return response;
    }
}


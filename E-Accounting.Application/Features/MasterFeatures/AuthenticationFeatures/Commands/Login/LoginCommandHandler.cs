using E_Accounting.Application.Abstraction.JWT;
using E_Accounting.Application.Messaging;
using E_Accounting.Application.Services.AuthenticationServices;
using E_Accounting.Domain.DTOs;
using E_Accounting.Domain.Entities.App_Entites;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace E_Accounting.Application.Features.MasterFeatures.AuthenticationFeatures.Commands.Login
{
    public class LoginCommandHandler : ICommandHandler<LoginCommand, LoginCommandResponse>
    {
        private readonly IJwtProvider _jwtProvider;
        private readonly UserManager<AppUser> _userManager;
        private readonly IAuthenticationService _authenticationService;

        public LoginCommandHandler(IJwtProvider jwtProvider, UserManager<AppUser> userManager, IAuthenticationService authenticationService)
        {
            _jwtProvider = jwtProvider;
            _userManager = userManager;
            _authenticationService = authenticationService;
        }

        public async Task<LoginCommandResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            AppUser? user = await _authenticationService.GetByEmailOrUserNameAsync(request.EmailOrUserName);

            if (user == null)
                throw new Exception("Kullanıcı Bulunamadı");

            var checkUser = await _authenticationService.CheckPasswordAsync(user, request.Password);

            if (!checkUser) throw new Exception("Şifreniz Yanlış");

            List<UserAndCompanyRelationShip> companies = await _authenticationService.GetCompanyListByUserIdAsync(user.Id, cancellationToken);

            List<CompanyDto> companiesDto = companies.Select(x => new CompanyDto(x.Id, x.Company.Name)).ToList();

            if (companies.Count == 0)
            {
                throw new Exception("Herhangi bir şirkete kayıtlı değilsiniz.");
            }

            LoginCommandResponse response = new(
                Token: await _jwtProvider.CreateTokenAsync(user),
                Email: user.Email,
                UserId: user.Id,
                UserNameAndLastName: user.UserFirstAndLastName,
                Companies: companiesDto,
                Company: companiesDto[0],
                Year: DateTime.Now.Year
                );
            return response;
        }
    }
}

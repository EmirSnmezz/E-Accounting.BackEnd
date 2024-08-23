using E_Accounting.Application.Abstraction.JWT;
using E_Accounting.Domain.Entities.App_Entites;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace E_Accounting.Application.Features.MasterFeatures.MasterUserFeatures.Login
{
    public class LoginHandler : IRequestHandler<LoginRequest, LoginResponse>
    {
        private readonly IJwtProvider _jwtProvider;
        private readonly UserManager<AppUser> _userManager;

        public LoginHandler(IJwtProvider jwtProvider, UserManager<AppUser> userManager)
        {
            _jwtProvider = jwtProvider;
            _userManager = userManager;
        }

        public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            AppUser user = await _userManager.Users.Where(p => p.Email == request.EmailOrUserName || p.UserName == request.EmailOrUserName).FirstOrDefaultAsync();

            if (user == null)
                throw new Exception("Kullanıcı Bulunamadı");

            var checkUser = await _userManager.CheckPasswordAsync(user, request.Password);

            if (!checkUser) throw new Exception("Şifreniz Yanlış");

            List<string> roles = new();

            LoginResponse response = new()
            {
                Email = user.Email,
                NameAndLastName = user.UserFirstAndLastName,
                UserId = user.Id,
                Token = await _jwtProvider.CreateTokenAsync(user, roles),
            };

            return response;
        }
    }
}

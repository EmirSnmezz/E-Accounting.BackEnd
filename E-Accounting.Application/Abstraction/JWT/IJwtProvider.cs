using E_Accounting.Domain.DTOs;
using E_Accounting.Domain.Entities.App_Entites;

namespace E_Accounting.Application.Abstraction.JWT
{
    public interface IJwtProvider
    {
        Task<RefreshTokenDto> CreateTokenAsync(AppUser user);
    }
}

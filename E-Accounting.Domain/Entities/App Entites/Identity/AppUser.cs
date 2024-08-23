using Microsoft.AspNetCore.Identity;

namespace E_Accounting.Domain.Entities.App_Entites
{
    public sealed class AppUser : IdentityUser<string>
    {

        public string UserFirstAndLastName { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpires { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;

namespace E_Accounting.Domain.Entities.App_Entites.Identity
{
    public sealed class AppRole : IdentityRole<string>
    {
        public string Code { get; set; }
    }
}

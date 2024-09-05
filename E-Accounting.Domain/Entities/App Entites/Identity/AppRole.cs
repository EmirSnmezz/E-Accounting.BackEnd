using Microsoft.AspNetCore.Identity;

namespace E_Accounting.Domain.Entities.App_Entites.Identity
{
    public sealed class AppRole : IdentityRole<string>
    {
        public AppRole(string title, string code, string name)
        {
            Id = Guid.NewGuid().ToString();
            Code = code;
            Title = title;
            Name = name;
        }

        public string Code { get; set; }
        public string Title { get; set; }
    }
}

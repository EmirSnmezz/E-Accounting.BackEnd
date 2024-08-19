using E_Accounting.Domain.Entities.App_Entites;
using E_Accounting.Domain.Entities.App_Entites.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Persistance.Contexts
{
    public sealed class MasterDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public MasterDbContext(DbContextOptions options) : base(options)
        {
        }
        DbSet<Company> Companies { get; set; }
        DbSet<UserAndCompanyRelationship> UserAndCompanyRelationships {get; set;}
    }
}

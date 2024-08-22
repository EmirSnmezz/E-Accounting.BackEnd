using E_Accounting.Domain.Entities.App_Entites;
using E_Accounting.Domain.Entities.App_Entites.Identity;
using E_Accounting.Persistance.AssemblyReferance;
using E_Accounting.Persistance.Contexts;
using E_Accounting_BackEnd.API.Configurations.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace E_Accounting_BackEnd.API.Configurations
{
    public class PersistanceServiceInstaller : IServiceRegistration
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MasterDbContext>();
            services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<MasterDbContext>();
            services.AddAutoMapper(typeof(AssemblyManager).Assembly);
        }
    }
}


using E_Accounting.Application.Abstraction.JWT;
using E_Accounting_BackEnd.Infrastructer.Authentication;

namespace E_Accounting_BackEnd.API.Configurations.Abstraction
{
    public class InfrastructorDıServiceInstaller : IServiceRegistration
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IJwtProvider, JwtProvider>();    
        }
    }
}

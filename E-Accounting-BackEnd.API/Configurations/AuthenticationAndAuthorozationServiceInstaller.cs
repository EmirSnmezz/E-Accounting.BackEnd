using E_Accounting_BackEnd.API.Configurations.Abstraction;
using E_Accounting_BackEnd.API.OptionsSetup;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace E_Accounting_BackEnd.API.Configurations
{
    public class AuthenticationAndAuthorozationServiceInstaller : IServiceRegistration
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {

            services.ConfigureOptions<JWTBearerOptionsSetup>();
            services.ConfigureOptions<JWTOptionsSetup>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                                       .AddJwtBearer();
        }
    }
}

using E_Accounting.Application.Features.MasterFeatures.CompanyFeatures.Commands.CreateCompany;
using E_Accounting_BackEnd.API.Configurations.Abstraction;
using System.Reflection;

namespace E_Accounting_BackEnd.API.Configurations
{
    public class ApplicationServiceInstaller : IServiceRegistration
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateCompanyHandler).GetTypeInfo().Assembly));
        }
    }
}

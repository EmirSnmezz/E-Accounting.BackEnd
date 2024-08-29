using E_Accounting.Application.Behavior;
using E_Accounting.Application.Features.MasterFeatures.CompanyFeatures.Commands.CreateCompany;
using E_Accounting_BackEnd.API.Configurations.Abstraction;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System.Reflection;
using System.Reflection.Metadata;

namespace E_Accounting_BackEnd.API.Configurations
{
    public class ApplicationServiceInstaller : IServiceRegistration
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateCompanyCommandHandler).GetTypeInfo().Assembly));
            services.AddTransient(typeof(IPipelineBehavior<,>), (typeof(ValidationBehavior<,>)));
            services.AddValidatorsFromAssembly(typeof(AssemblyReference).Assembly);
        }
    }
}

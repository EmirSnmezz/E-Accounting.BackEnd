using E_Accounting.Application;
using E_Accounting.Application.Abstraction.Repositories.Repositories_Of_Entities.UCAF_Repositories;
using E_Accounting.Application.Services.CompanyService;
using E_Accounting.Application.Services.MasterService;
using E_Accounting.Persistance;
using E_Accounting.Persistance.AssemblyReferance;
using E_Accounting.Persistance.Repositories.Repositories_Of_Entities.UCAF_Repositories;
using E_Accounting.Persistance.Service.CompanyService;
using E_Accounting.Persistance.Service.MasterService;
using E_Accounting_BackEnd.API.Configurations.Abstraction;

namespace E_Accounting_BackEnd.API.Configurations
{
    public class PersistanceIoCServiceInstaller : IServiceRegistration
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            #region Context UnitOfWork
            services.AddScoped<IContextService, ContextService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            #endregion

            #region Services
            services.AddScoped<IUCAFService, UCAFService>();
            services.AddScoped<ICompanyService, CompanyService>();
            #endregion

            #region Repositories
            services.AddScoped<IUCAFCommandRepository, UCAFCommandRepository>();
            services.AddScoped<IUCAFQueryRepository, UCAFQueryRepository>();
            #endregion
        }
    }
}

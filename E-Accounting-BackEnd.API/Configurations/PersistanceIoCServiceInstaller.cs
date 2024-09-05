using E_Accounting.Application;
using E_Accounting.Application.Abstraction.Repositories.Repositories_Of_Entities.UCAF_Repositories;
using E_Accounting.Application.Services.CompanyService;
using E_Accounting.Application.Services.MasterService;
using E_Accounting.Application.UnitOfWorks;
using E_Accounting.Domain.Repositories.GenericRepositories.AppDbContext;
using E_Accounting.Domain.Repositories.GenericRepositories.CompanyDbContext;
using E_Accounting.Persistance;
using E_Accounting.Persistance.Contexts;
using E_Accounting.Persistance.Repositories.GenericRepositories.MasterDbContext;
using E_Accounting.Persistance.Repositories.GenericRepositories.MasterDbContext.CompanyRepositories;
using E_Accounting.Persistance.Repositories.Repositories_Of_Entities.UCAF_Repositories;
using E_Accounting.Persistance.Service.CompanyService;
using E_Accounting.Persistance.Service.MasterService;
using E_Accounting.Persistance.Service.Role_Service;
using E_Accounting.Persistance.UnitOfWorkds;
using E_Accounting_BackEnd.API.Configurations.Abstraction;

namespace E_Accounting_BackEnd.API.Configurations
{
    public class PersistanceIoCServiceInstaller : IServiceRegistration
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            #region Context UnitOfWork
            services.AddScoped<IContextService, ContextService>();
            services.AddScoped<IMasterUnitOfWork, MasterDbUnitOfWork>();
            services.AddScoped<ICompanyUnitOfWork, CompanyDbUnitOfWork>();
            services.AddScoped<CompanyDbContext, CompanyDbContext>();

            #region Services
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IUCAFService, UCAFService>();
            services.AddScoped<IRoleService, RoleService>();
            #endregion


            #endregion

            #region Services

            #region CompanyDbContext
            services.AddScoped<IUCAFCommandRepository, UCAFCommandRepository>();
            services.AddScoped<IUCAFQueryRepository, UCAFQueryRepository>();
            #endregion

            #region MasterDbContext
            services.AddScoped<ICompanyCommandRepository, CompanyCommandRepository>();
            services.AddScoped<ICompanyQueryRepository, CompanyQueryRepository>();
            #endregion

            #endregion

            #region Repositories
            #endregion
        }
    }
}

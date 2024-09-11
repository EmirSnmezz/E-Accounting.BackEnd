using E_Accounting.Application;
using E_Accounting.Application.Abstraction.Repositories.MainRoleRepositories;
using E_Accounting.Application.Abstraction.Repositories.Repositories_Of_Entities.MasterDbContext.CompanyRepositories;
using E_Accounting.Application.Abstraction.Repositories.Repositories_Of_Entities.MasterDbContext.MainRoleAndRoleRelationShipRepositories;
using E_Accounting.Application.Abstraction.Repositories.Repositories_Of_Entities.MasterDbContext.MainRoleAndUserRelationShipRepositories;
using E_Accounting.Application.Abstraction.Repositories.Repositories_Of_Entities.MasterDbContext.UserAndCompanyRelationShipRepositories;
using E_Accounting.Application.Abstraction.Repositories.Repositories_Of_Entities.UCAF_Repositories;
using E_Accounting.Application.Services.CompanyService;
using E_Accounting.Application.Services.MainRoleAndRoleRelationShipService;
using E_Accounting.Application.Services.MainRoleAndUserRelationShipService;
using E_Accounting.Application.Services.MasterService;
using E_Accounting.Application.Services.UserAndCompanyRelationShipService;
using E_Accounting.Application.UnitOfWorks;
using E_Accounting.Domain.Repositories.GenericRepositories.AppDbContext;
using E_Accounting.Domain.Repositories.GenericRepositories.CompanyDbContext;
using E_Accounting.Persistance;
using E_Accounting.Persistance.Contexts;
using E_Accounting.Persistance.Repositories.GenericRepositories.MasterDbContext;
using E_Accounting.Persistance.Repositories.GenericRepositories.MasterDbContext.CompanyRepositories;
using E_Accounting.Persistance.Repositories.GenericRepositories.MasterDbContext.MainRoleAndRoleRelationShipRepositories;
using E_Accounting.Persistance.Repositories.GenericRepositories.MasterDbContext.MainRoleAndUserRelationShipRepositories;
using E_Accounting.Persistance.Repositories.GenericRepositories.MasterDbContext.MainRoleRepository;
using E_Accounting.Persistance.Repositories.GenericRepositories.MasterDbContext.UserAndCompanyRelationShipRepository;
using E_Accounting.Persistance.Repositories.Repositories_Of_Entities.UCAF_Repositories;
using E_Accounting.Persistance.Service.CompanyService;
using E_Accounting.Persistance.Service.MasterDbServices.CompanyService;
using E_Accounting.Persistance.Service.MasterDbServices.MainRoleAndRelationShipService;
using E_Accounting.Persistance.Service.MasterDbServices.MainRoleAndUserRelationShipService;
using E_Accounting.Persistance.Service.MasterDbServices.MainRoleService;
using E_Accounting.Persistance.Service.MasterDbServices.UserAndCompanyRelationShipService;
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
            services.AddScoped<IMainRoleService, MainRoleService>();
            services.AddScoped<IMainRoleAndRoleRelationShipService, MainRoleAndRoleRelationShipService>();
            services.AddScoped<IMainRoleAndUserRelationShipService, MainRoleAndUserRelationShipService>();
            services.AddScoped<IUserAndCompanyRelationShipService, UserAndCompanyRelationShipService>();
            #endregion


            #endregion

          

            #region CompanyDbContext
            services.AddScoped<IUCAFCommandRepository, UCAFCommandRepository>();
            services.AddScoped<IUCAFQueryRepository, UCAFQueryRepository>();
            #endregion

            #region Services
            #endregion

            #region Repositories

            #region MasterDbContext
            services.AddScoped<ICompanyCommandRepository, CompanyCommandRepository>();
            services.AddScoped<ICompanyQueryRepository, CompanyQueryRepository>();
            services.AddScoped<IMainRoleCommandRepository, MainRoleCommandRepository>();
            services.AddScoped<IMainRoleQueryRepository, MainRoleQueryRepository>();
            services.AddScoped<IMainRoleAndRoleRelationShipCommandRepository, MainRoleAndRoleRelationShipCommandRepository>();
            services.AddScoped<IMainRoleAndRoleRelationShipQueryRepository, MainRoleAndRoleRelationShipQueryRepository>();
            services.AddScoped<IUserAndCompanyRelationShipCommandRepository, UserAndCompanyRelationShipCommandRepository>();
            services.AddScoped<IUserAndCompanyRelationShipQueryRepository, UserAndCompanyRelationShipQueryRepository>();
            services.AddScoped<IMainRoleAndUserRelationShipCommandRepository, MainRoleAndUserRelationShipCommandRepository>();
            services.AddScoped<IMainRoleAndUserRelationShipQueryRepository, MainRoleAndUserrelationShipQueryRepoistory>();
            #endregion

            #endregion
      
        }
    }
}

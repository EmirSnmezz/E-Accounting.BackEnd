using E_Accounting.Application.Abstraction.Repositories.MainRoleRepositories;
using E_Accounting.Domain.Entities.App_Entites;
using E_Accounting.Persistance.Repositories.GenericRepositories.MasterDbContext.BaseRepositories;

namespace E_Accounting.Persistance.Repositories.GenericRepositories.MasterDbContext.MainRoleRepository
{
    public class MainRoleCommandRepository : MasterCommandRepository<MainRole>, IMainRoleCommandRepository
    {
        public MainRoleCommandRepository(Contexts.MasterDbContext context) : base(context)
        {
        }
    }
}

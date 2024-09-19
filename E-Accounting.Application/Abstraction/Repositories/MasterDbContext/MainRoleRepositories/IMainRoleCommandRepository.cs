using E_Accounting.Application.Abstraction.Repositories.BaseRepositories;
using E_Accounting.Domain.Entities.App_Entites;
using E_Accounting.Domain.Repositories.GenericRepositories;

namespace E_Accounting.Application.Abstraction.Repositories.MainRoleRepositories
{
    public interface IMainRoleCommandRepository : ICommandGenericRepository<MainRole>
    {
    }
}

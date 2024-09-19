using E_Accounting.Application.Abstraction.Repositories.Repositories_Of_Entities.MasterDbContext.MainRoleAndUserRelationShipRepositories;
using E_Accounting.Domain.Entities.App_Entites;
using E_Accounting.Persistance.Repositories.GenericRepositories.MasterDbContext.BaseRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Persistance.Repositories.GenericRepositories.MasterDbContext.MainRoleAndUserRelationShipRepositories
{
    public class MainRoleAndUserRelationShipCommandRepository : MasterCommandRepository<MainRoleAndUserRelationShip>, IMainRoleAndUserRelationShipCommandRepository
    {
        public MainRoleAndUserRelationShipCommandRepository(Contexts.MasterDbContext context) : base(context)
        {
        }
    }
}

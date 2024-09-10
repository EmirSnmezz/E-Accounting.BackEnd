using E_Accounting.Application.Abstraction.Repositories.Repositories_Of_Entities.MasterDbContext.MainRoleAndRoleRelationShipRepositories;
using E_Accounting.Domain.Entities.App_Entites;
using E_Accounting.Persistance.Repositories.GenericRepositories.MasterDbContext.BaseRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Persistance.Repositories.GenericRepositories.MasterDbContext.MainRoleAndRoleRelationShipRepositories
{
    public class MainRoleAndRoleRelationShipQueryRepository : MasterQueryRepository<MainRoleAndRoleRelationship>, IMainRoleAndRoleRelationShipQueryRepository
    {
        public MainRoleAndRoleRelationShipQueryRepository(Contexts.MasterDbContext context) : base(context)
        {
        }
    }
}

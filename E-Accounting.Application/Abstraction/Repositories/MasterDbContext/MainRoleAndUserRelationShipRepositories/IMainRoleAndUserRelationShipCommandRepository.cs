﻿using E_Accounting.Application.Abstraction.Repositories.BaseRepositories;
using E_Accounting.Domain.Entities.App_Entites;
using E_Accounting.Domain.Repositories.GenericRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Application.Abstraction.Repositories.Repositories_Of_Entities.MasterDbContext.MainRoleAndUserRelationShipRepositories
{
    public interface IMainRoleAndUserRelationShipCommandRepository : ICommandGenericRepository<MainRoleAndUserRelationShip>
    {
    }
}

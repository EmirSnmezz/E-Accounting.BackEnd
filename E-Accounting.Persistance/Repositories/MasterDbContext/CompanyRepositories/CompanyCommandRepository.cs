using E_Accounting.Application.Abstraction.Repositories.Repositories_Of_Entities.MasterDbContext.CompanyRepositories;
using E_Accounting.Domain.Entities.App_Entites;
using E_Accounting.Domain.Repositories.GenericRepositories.AppDbContext;
using E_Accounting.Domain.Repositories.GenericRepositories.CompanyDbContext;
using E_Accounting.Persistance.Contexts;
using E_Accounting.Persistance.Repositories.GenericRepositories.MasterDbContext.BaseRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Persistance.Repositories.GenericRepositories.MasterDbContext.CompanyRepositories
{
    public class CompanyCommandRepository : MasterCommandRepository<Company>, ICompanyCommandRepository
    {
        public CompanyCommandRepository(Contexts.MasterDbContext context) : base(context)
        {
        }
    }
}

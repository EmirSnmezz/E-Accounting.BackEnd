﻿using E_Accounting.Application;
using E_Accounting.Domain.Entities.App_Entites;
using E_Accounting.Persistance.Context;
using E_Accounting.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;

namespace E_Accounting.Persistance
{
    public sealed class ContextService : IContextService
    {
        private readonly MasterDbContext _contextService;
        public ContextService(MasterDbContext contextService)
        {
            _contextService = contextService;
        }
        public DbContext CreateDbContextInstance(string companyId)
        {
            Company company = ((MasterDbContext)_contextService).Set<Company>().Find(companyId);
            return new CompanyDbContext(company);
        }
    }
}                           

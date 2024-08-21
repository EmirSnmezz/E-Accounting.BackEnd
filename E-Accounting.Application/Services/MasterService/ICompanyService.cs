﻿using E_Accounting.Application.Features.CompanyFeatures.Commands.CreateCompany;
using E_Accounting.Application.Features.CompanyFeatures.Commands.MigrateCompanyDatabase;
using E_Accounting.Domain.Entities.App_Entites;

namespace E_Accounting.Application.Services.MasterService
{
    public interface ICompanyService
    {
        Task CreateCompany ( CreateCompanyRequest request );
        Task MigrateCompanyDatabase();
        Task <Company?> GetCompanyByName ( string companyName );
    }
}
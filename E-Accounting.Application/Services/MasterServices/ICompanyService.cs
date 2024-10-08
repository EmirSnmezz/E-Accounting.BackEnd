﻿
using E_Accounting.Application.Features.MasterFeatures.CompanyFeatures.Commands.CreateCompany;
using E_Accounting.Domain.Entities.App_Entites;

namespace E_Accounting.Application.Services.MasterService
{
    public interface ICompanyService
    {
        Task CreateCompany(CreateCompanyCommand request, CancellationToken cancellationToken);
        Task MigrateCompanyDatabase();
        Task<Company?> GetCompanyByName(string companyName, CancellationToken cancellationToken);
        IQueryable<Company> GetAll();
        Task<Company?> GetById(string id);
        Task UpdateAsync(Company company);
        Task RemoveByIdAsync(string id);
    }
}

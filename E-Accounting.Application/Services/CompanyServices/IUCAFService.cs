using E_Accounting.Application.Features.Company_Features.UCAFFeautres.Commands.CreateUCAF;
using E_Accounting.Application.Features.CompanyFeatures.UCAFFeautres.Queries.GetAllUCAF;
using E_Accounting.Application.Features.MasterFeatures.CompanyFeatures.Queries;
using E_Accounting.Domain.Entities.CompanyEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Application.Services.CompanyService
{
    public interface IUCAFService
    {
        Task CreateUcafAsync(CreateUCAFCommand request, CancellationToken cancellationToken);
        Task<UniformChartOfAccount> GetByCode(string code, CancellationToken cancellationToken);
        IQueryable<UniformChartOfAccount> GetAll();
    }
}

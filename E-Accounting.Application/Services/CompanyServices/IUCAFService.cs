using E_Accounting.Application.Features.Company_Features.UCAFFeautres.Commands.CreateUCAF;
using E_Accounting.Domain.Entities.CompanyEntities;

namespace E_Accounting.Application.Services.CompanyService
{
    public interface IUCAFService
    {
        Task<UniformChartOfAccount> CreateUcafAsync(CreateUCAFCommand request, CancellationToken cancellationToken);
        Task<UniformChartOfAccount> GetByCode(string code, CancellationToken cancellationToken);
        Task CreateMainUCAFsToCompany(string companyId, CancellationToken cancellationToken);
        IQueryable<UniformChartOfAccount> GetAll();
    }
}

using E_Accounting.Application.Features.Company_Features.UCAFFeautres.Commands.CreateUCAF;
using E_Accounting.Domain.Entities.CompanyEntities;

namespace E_Accounting.Application.Services.CompanyService
{
    public interface IUCAFService
    {
        Task<UniformChartOfAccount> CreateUcafAsync(CreateUCAFCommand request, CancellationToken cancellationToken); 
        Task<UniformChartOfAccount> GetByCodeAsync(string companyId, string code, CancellationToken cancellationToken);
        Task CreateMainUCAFsToCompanyAsync(string companyId, CancellationToken cancellationToken);
        Task<IQueryable<UniformChartOfAccount>> GetAllAsync(string companyId); //ok
        Task RemoveByIdUcafAsync(string id, string companyId);
        Task<bool> CheckRemoveByIdUcafIsGroupAndAvailable(string id, string companyId);
        Task<UniformChartOfAccount> GetByIdAsync(string id, string companyId); 
        Task UpdateAsync(UniformChartOfAccount account, string companyId);
    }
}

using AutoMapper;
using E_Accounting.Application.Abstraction.Repositories.Repositories_Of_Entities.MasterDbContext.CompanyRepositories;
using E_Accounting.Application.Features.MasterFeatures.CompanyFeatures.Commands.CreateCompany;
using E_Accounting.Application.Services.CompanyService;
using E_Accounting.Application.Services.MasterService;
using E_Accounting.Application.UnitOfWorks;
using E_Accounting.Domain.Entities.App_Entites;
using E_Accounting.Domain.Repositories.GenericRepositories.CompanyDbContext;
using E_Accounting.Persistance.Context;
using E_Accounting.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;

namespace E_Accounting.Persistance.Service.MasterDbServices.CompanyService
{
    public sealed class CompanyService : ICompanyService
    {
        private readonly ICompanyCommandRepository _commandRepository;
        private readonly ICompanyQueryRepository _queryRepository;
        private readonly IMasterUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CompanyService(IMapper mapper, ICompanyCommandRepository repository, IMasterUnitOfWork unitOfWork, ICompanyQueryRepository queryRepository)
        {
            _unitOfWork = unitOfWork;
            _commandRepository = repository;
            _queryRepository = queryRepository;
            _mapper = mapper;
        }

        public async Task CreateCompany(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            Company company = _mapper.Map<Company>(request);
            company.Id = Guid.NewGuid().ToString();
            await _commandRepository.AddAsync(company, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        public IQueryable<Company> GetAll()
        {
            return _queryRepository.GetAll().OrderBy(x => x.Name);
        }

        public async Task<Company> GetById(string id)
        {
            return await _queryRepository.GetById(id);
        }

        public async Task<Company> GetCompanyByName(string companyName, CancellationToken cancellationToken)
        {
            return await _queryRepository.GetFirstByExpression(x => x.Name == companyName, cancellationToken, false);
        }

        public async Task MigrateCompanyDatabase()
        {
            try
            {
                var companies = await _queryRepository.GetAll().ToListAsync();
                foreach (var company in companies)
                {
                    var db = new CompanyDbContext(company);
                    db.Database.Migrate();
                }
            }catch (Exception ex)
            {
                throw new Exception("Buraya hata düştü");
            }
          
        }

        public async Task RemoveByIdAsync(string id)
        {
           await _commandRepository.RemoveById(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(Company company)
        {
            _commandRepository.Update(company);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}

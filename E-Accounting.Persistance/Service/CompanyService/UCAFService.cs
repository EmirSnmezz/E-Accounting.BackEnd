using AutoMapper;
using E_Accounting.Application;
using E_Accounting.Application.Abstraction.Repositories.Repositories_Of_Entities.UCAF_Repositories;
using E_Accounting.Application.Features.Company_Features.UCAFFeautres.Commands.CreateUCAF;
using E_Accounting.Application.Services.CompanyService;
using E_Accounting.Domain.Entities.CompanyEntities;
using E_Accounting.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Persistance.Service.CompanyService
{
    public class UCAFService : IUCAFService
    {
        private readonly IUCAFCommandRepository _commandRepository;
        private readonly IContextService _contextService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private CompanyDbContext _companyDbContext;
        public UCAFService(IUCAFCommandRepository commandRepository, IContextService contextService, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _commandRepository = commandRepository;
            _contextService = contextService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateUcafAsync(CreateUCAFCommand request)
        {
            _companyDbContext = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
            _commandRepository.SetDbContextInstance(_companyDbContext);
            _unitOfWork.SetDbContextInstance(_companyDbContext);
            UniformChartOfAccount uniformChartOfAccount = _mapper.Map<UniformChartOfAccount>(request);
            uniformChartOfAccount.Id = Guid.NewGuid().ToString();

            await _commandRepository.AddAsync(uniformChartOfAccount);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}

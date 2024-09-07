using AutoMapper;
using E_Accounting.Application;
using E_Accounting.Application.Abstraction.Repositories.Repositories_Of_Entities.UCAF_Repositories;
using E_Accounting.Application.Features.Company_Features.UCAFFeautres.Commands.CreateUCAF;
using E_Accounting.Application.Services.CompanyService;
using E_Accounting.Application.UnitOfWorks;
using E_Accounting.Domain.Entities.CompanyEntities;
using E_Accounting.Persistance.Contexts;
using System.Threading;

namespace E_Accounting.Persistance.Service.CompanyService
{
    public class UCAFService : IUCAFService
    {
        private readonly IUCAFCommandRepository _commandRepository;
        private readonly IContextService _contextService;
        private readonly IUCAFQueryRepository _ıUcafQueryRepository;
        private readonly ICompanyUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private CompanyDbContext _companyDbContext;
        public UCAFService(IUCAFCommandRepository commandRepository, IContextService contextService, ICompanyUnitOfWork unitOfWork, IMapper mapper, IUCAFQueryRepository ıUcafQueryRepository)
        {
            _commandRepository = commandRepository;
            _ıUcafQueryRepository = ıUcafQueryRepository;
            _contextService = contextService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateUcafAsync(CreateUCAFCommand request, CancellationToken cancellationToken)
        {
            _companyDbContext = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
            _unitOfWork.SetDbContextInstance(_companyDbContext);
            UniformChartOfAccount uniformChartOfAccount = _mapper.Map<UniformChartOfAccount>(request);
            uniformChartOfAccount.Id = Guid.NewGuid().ToString();

            await _commandRepository.AddAsync(uniformChartOfAccount, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task<UniformChartOfAccount> GetByCode(string code, CancellationToken cancellationToken)
        {
            return await  _ıUcafQueryRepository.GetFirstByExpression(x => x.Code == code, cancellationToken);
        }
    }
}

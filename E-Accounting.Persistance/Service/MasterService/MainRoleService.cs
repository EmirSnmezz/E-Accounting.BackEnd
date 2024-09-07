using E_Accounting.Application.Abstraction.Repositories.MainRoleRepositories;
using E_Accounting.Application.Services.MasterService;
using E_Accounting.Application.UnitOfWorks;
using E_Accounting.Domain.Entities.App_Entites;

namespace E_Accounting.Persistance.Service.MasterService;

public sealed class MainRoleService : IMainRoleService
{
    private readonly IMainRoleCommandRepository _commandRepository;
    private readonly IMainRoleQueryRepository _queryRepository;
    private readonly IMasterUnitOfWork _unitOfWork;
    public MainRoleService(IMainRoleCommandRepository commandRepository, IMainRoleQueryRepository queryRepository, IMasterUnitOfWork unitOfWork)
    {
        _commandRepository = commandRepository;
        _queryRepository = queryRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task CreateAsync(MainRole mainRole, CancellationToken cancellationToken)
    {
        await _commandRepository.AddAsync(mainRole, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task CreateRangeAsync(List<MainRole> mainRoles, CancellationToken cancellationToken)
    {
        await _commandRepository.AddRangeAsync(mainRoles, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public IList<MainRole> GetAll()
    {
        return _queryRepository.GetAll().ToList();
    }

    public async Task<MainRole> GetByTitleAndCompanyId(string title, string companyId, CancellationToken cancellationToken)
    {
        //if (companyId == null)
        //{
        //    return await _queryRepository.GetFirstByExpression(x => x.Title == title, cancellationToken, false);
        //}

        return await _queryRepository.GetFirstByExpression(x => x.Title == title && x.CompanyId == companyId, cancellationToken, false);
    }
}
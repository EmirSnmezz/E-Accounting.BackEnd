using E_Accounting.Application.Abstraction.Repositories.Repositories_Of_Entities.MasterDbContext.MainRoleAndUserRelationShipRepositories;
using E_Accounting.Application.Services.MainRoleAndUserRelationShipService;
using E_Accounting.Application.UnitOfWorks;
using E_Accounting.Domain.Entities.App_Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace E_Accounting.Persistance.Service.MasterDbServices.MainRoleAndUserRelationShipService
{
    public class MainRoleAndUserRelationShipService : IMainRoleAndUserRelationShipService
    {
        private readonly IMainRoleAndUserRelationShipCommandRepository _commandRepository;
        private readonly IMainRoleAndUserRelationShipQueryRepository _queryRepository;
        private readonly IMasterUnitOfWork _unitOfWork;

        public MainRoleAndUserRelationShipService(IMainRoleAndUserRelationShipCommandRepository commandRepository, IMainRoleAndUserRelationShipQueryRepository queryRepository, IMasterUnitOfWork unitOfWork)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(MainRoleAndUserRelationShip mainRoleAndUserRelationShip, CancellationToken cancellationToken)
        {
            await _commandRepository.AddAsync(mainRoleAndUserRelationShip, cancellationToken);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<MainRoleAndUserRelationShip> GetById(string id)
        {
           var entity = await _queryRepository.GetById(id);
            return entity;
        }

        public async Task<MainRoleAndUserRelationShip> GetByUserIdCompanyIdAndMainRoleId(string userId, string companyId, string mainRoleId , CancellationToken cancellationToken)
        {
            var mainRoleAndUserRelationShip =  await _queryRepository.GetFirstByExpression(x => x.UserId == userId && x.CompanyId == companyId && x.MainRoleId == mainRoleId, cancellationToken);
            return mainRoleAndUserRelationShip;
        }

        public async Task<MainRoleAndUserRelationShip> GetRolesByUserIdAndCompanyId(string userId, string companyId, CancellationToken cancellation = default)
        {
            var result = await _queryRepository.GetFirstByExpression(x => x.UserId == userId && x.CompanyId == companyId, cancellation);
            return result;
        }

        public async Task RemoveById(string id)
        {
            await _commandRepository.RemoveById(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}

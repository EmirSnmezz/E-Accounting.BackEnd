using E_Accounting.Application.Abstraction.Repositories.Repositories_Of_Entities.MasterDbContext.UserAndCompanyRelationShipRepositories;
using E_Accounting.Application.Services.UserAndCompanyRelationShipService;
using E_Accounting.Application.UnitOfWorks;
using E_Accounting.Domain.Entities.App_Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Persistance.Service.MasterDbServices.UserAndCompanyRelationShipService
{
    public class UserAndCompanyRelationShipService : IUserAndCompanyRelationShipService
    {
        public readonly IUserAndCompanyRelationShipCommandRepository _commadRepository;
        public readonly IUserAndCompanyRelationShipQueryRepository _queryRepository;
        public readonly IMasterUnitOfWork _unitOfWork;

        public UserAndCompanyRelationShipService(IUserAndCompanyRelationShipCommandRepository commandRepository, IUserAndCompanyRelationShipQueryRepository queryRepository, IMasterUnitOfWork unitOfWork)
        {
            _commadRepository = commandRepository;
            _queryRepository = queryRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task CreateAsync(UserAndCompanyRelationShip userAndCompanyRelationShip, CancellationToken cancellationToken)
        {
            await _commadRepository.AddAsync(userAndCompanyRelationShip, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task<UserAndCompanyRelationShip> GetByIdAsync(string id, CancellationToken cancellationToken)
        {
            return await _queryRepository.GetById(id);
        }

        public async Task<UserAndCompanyRelationShip> GetByUserIdAndCompanyId(string userId, string companyId, CancellationToken cancellationToken)
        {
            return await _queryRepository.GetFirstByExpression(x => x.MasterUserId == userId && x.CompanyId == companyId, cancellationToken);
        }

        public async Task RemoveByIdAsync(string id, CancellationToken cancellationToken)
        {
             await _commadRepository.RemoveById(id);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(UserAndCompanyRelationShip userAndCompanyRelationShip, CancellationToken cancellationToken1)
        {
            _commadRepository.Update(userAndCompanyRelationShip);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}

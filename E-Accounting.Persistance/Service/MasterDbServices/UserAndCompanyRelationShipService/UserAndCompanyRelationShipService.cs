using E_Accounting.Application.Abstraction.Repositories.Repositories_Of_Entities.MasterDbContext.UserAndCompanyRelationShipRepositories;
using E_Accounting.Application.Services.UserAndCompanyRelationShipService;
using E_Accounting.Application.UnitOfWorks;
using E_Accounting.Domain.Entities.App_Entites;
using Microsoft.EntityFrameworkCore;

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
            var result = await _queryRepository.GetFirstByExpression(x => x.MasterUserId == userId && x.CompanyId == companyId, cancellationToken);
            return result;
        }

        public async Task<IList<UserAndCompanyRelationShip>> GetCompanyListByUserId(string userId, CancellationToken cancellationToken)
        {
            var result = await _queryRepository.GetWhere(x => x.MasterUserId == userId).Include("Company").OrderBy(x => x.Company.Name).ToListAsync(cancellationToken);
            return result;
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

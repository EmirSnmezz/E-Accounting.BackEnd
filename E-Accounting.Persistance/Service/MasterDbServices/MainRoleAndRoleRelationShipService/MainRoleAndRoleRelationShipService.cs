using E_Accounting.Application.Abstraction.Repositories.Repositories_Of_Entities.MasterDbContext.MainRoleAndRoleRelationShipRepositories;
using E_Accounting.Application.Services.MainRoleAndRoleRelationShipService;
using E_Accounting.Application.UnitOfWorks;
using E_Accounting.Domain.Entities.App_Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace E_Accounting.Persistance.Service.MasterDbServices.MainRoleAndRelationShipService
{
    public class MainRoleAndRoleRelationShipService : IMainRoleAndRoleRelationShipService
    {
        private readonly IMainRoleAndRoleRelationShipCommandRepository _commandRepository;
        private readonly IMainRoleAndRoleRelationShipQueryRepository _queryRepository;
        private readonly IMasterUnitOfWork _unitOfWork;

        public MainRoleAndRoleRelationShipService(IMainRoleAndRoleRelationShipCommandRepository commandRepository, IMainRoleAndRoleRelationShipQueryRepository queryRepository, IMasterUnitOfWork unitOfWork)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(MainRoleAndRoleRelationship mainRoleAndRoleRelationship, CancellationToken cancellationToken)
        {
            await _commandRepository.AddAsync(mainRoleAndRoleRelationship, cancellationToken);
            await _unitOfWork.SaveChangesAsync();
        }

        public IQueryable<MainRoleAndRoleRelationship> GetAll()
        {
            return _queryRepository.GetAll().OrderBy(x => x.MainRole.Title).AsQueryable();
        }

        public async Task<MainRoleAndRoleRelationship> GetByIdAsnyc(string id, CancellationToken cancellationToken)
        {
            return await _queryRepository.GetById(id);
        }

        public async Task<List<MainRoleAndRoleRelationship>> GetListByIdForGetRolesAsync(string id, CancellationToken cancellationToken)
        {
            var result =  await _queryRepository.GetWhere(x => x.MainRoleId == id).Include("AppRole").OrderBy(x => x.Id).ToListAsync();
            return result;
        }

        public async Task<MainRoleAndRoleRelationship> GetByRoleIdAndMainRoleId(string roleId, string mainRoleId, CancellationToken cancellationToken)
        {
            return await _queryRepository.GetFirstByExpression(x => x.RoleId == roleId && x.MainRoleId == mainRoleId, cancellationToken);
        }

        public async Task RemoveById(string id, CancellationToken cancellationToken)
        {
            await _commandRepository.RemoveById(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(MainRoleAndRoleRelationship mainRoleAndRoleRelationship, CancellationToken cancellationToken)
        {
            _commandRepository.Update(mainRoleAndRoleRelationship);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}

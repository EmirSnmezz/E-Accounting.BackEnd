using E_Accounting.Application.Features.MasterFeatures.MainRoleAndRoleRelationShipFeatures.Commands;
using E_Accounting.Application.Services.MainRoleAndRoleRelationShipService;
using E_Accounting.Domain.Entities.App_Entites;
using E_Accounting.Persistance.Service.MasterDbServices.MainRoleAndRelationShipService;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.BackEnd.UnitTest.Features.AppFeature.AppFeatureUsers.MainRoleAndRoleRelationShipFeature
{
    public class CreateMainRoleAndRoleRelationShipCommandUnitTest
    {
        private readonly Mock<IMainRoleAndRoleRelationShipService> _service;

        public CreateMainRoleAndRoleRelationShipCommandUnitTest()
        {
            _service = new();
        }

        [Fact]
        public async Task MainRoleAndRoleRelationShipShouldBeNull()
        {
            MainRoleAndRoleRelationship entity = await _service.Object.GetByRoleIdAndMainRoleId(roleId : "TestId" , mainRoleId : "TestId", default);    
            entity.ShouldBeNull();
        }

        [Fact]
        public async Task CreateMainRoleAndRoleRelationShipCommandShouldNotBeNull()
        {
            CreateMainRoleAndRoleRelationShipCommand request = new(RoleId : Guid.NewGuid().ToString(), MainRoleId : Guid.NewGuid().ToString());
            CreateMainRoleAndRoleRelationShipCommandHandler handler = new(_service.Object);
            CreateMainRoleAndRoleRelationShipsCommandResponse response = await handler.Handle(request, default);
            response.ShouldNotBeNull();
            response.Message.ShouldNotBeEmpty();

        }

    }
}

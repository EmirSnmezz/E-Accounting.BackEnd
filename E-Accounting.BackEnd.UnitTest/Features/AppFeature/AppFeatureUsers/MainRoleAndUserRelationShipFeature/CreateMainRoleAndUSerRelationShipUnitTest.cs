using E_Accounting.Application.Features.MasterFeatures.MainRoleAndUserRelationShipFeatures.Command.Create;
using E_Accounting.Application.Services.MainRoleAndUserRelationShipService;
using E_Accounting.Domain.Entities.App_Entites;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.BackEnd.UnitTest.Features.AppFeature.AppFeatureUsers.MainRoleAndUserRelationShipFeature
{
    public sealed class CreateMainRoleAndUSerRelationShipUnitTest
    {
        private readonly Mock<IMainRoleAndUserRelationShipService> _service;

        public CreateMainRoleAndUSerRelationShipUnitTest()
        {
            _service = new();
        }

        [Fact]
        public async Task checkMainRoleAndUserRelationShipShouldBeNull()
        {
            MainRoleAndUserRelationShip entity = await _service.Object.GetByUserIdCompanyIdAndMainRoleId(userId : "", companyId : "", mainRoleId : "", cancellation : default(CancellationToken));

            entity.ShouldBeNull();
        }

        [Fact]
        public async Task CreateMainRoleAndUserRelationShipResponseShouldNotBeNull()
        {
            CreateMainRoleAndUserRelationShipCommand request = new(userId: "TestId", mainRoleId: "TestId", companyId: "TestId");
            CreateMainRoleAndUserRelationShipCommandHandler handler = new(_service.Object);
            CreateMainRoleAndUserRelationShipCommandResponse response = await handler.Handle(request, default);
            response.ShouldNotBeNull();
            response.Message.ShouldNotBeEmpty();
        }
    }
}

using E_Accounting.Application.Features.MasterFeatures.MainRoleAndRoleRelationShipFeatures.Commands.Remove;
using E_Accounting.Application.Services.MainRoleAndRoleRelationShipService;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.BackEnd.UnitTest.Features.AppFeature.AppFeatureUsers.MainRoleAndRoleRelationShipFeature
{
    public sealed class RemoveMainRoleAndRoleRelationShipCommandUnitTest
    {
        private readonly Mock<IMainRoleAndRoleRelationShipService> _service;

        public RemoveMainRoleAndRoleRelationShipCommandUnitTest()
        {
            _service = new();
        }

        [Fact]
        public async Task ShouldNotBeNull()
        {
            _service.Setup(x => x
            .GetByIdAsnyc(It.IsAny<string>(), default))
                .ReturnsAsync(new Domain.Entities.App_Entites.MainRoleAndRoleRelationship())
                .ShouldNotBeNull();
        }

        [Fact]
        public async Task RemoveMainRoleAndRoleRelationShipCommandShouldNotBeNull()
        {
            RemoveMainRoleAndRoleRelationShipCommand request = new(Id: "TestId");
            RemoveMainRoleAndRoleRelationShipCommandHandler handler = new(_service.Object);

            _service.Setup(x => x
          .GetByIdAsnyc(It.IsAny<string>(), default))
              .ReturnsAsync(new Domain.Entities.App_Entites.MainRoleAndRoleRelationship())
              .ShouldNotBeNull();

            RemoveMainRoleAndRoleRelationShipCommandResponse response = await handler.Handle(request, default);
            response.ShouldNotBeNull();
            response.Message.ShouldNotBeEmpty();
        }
    }
}

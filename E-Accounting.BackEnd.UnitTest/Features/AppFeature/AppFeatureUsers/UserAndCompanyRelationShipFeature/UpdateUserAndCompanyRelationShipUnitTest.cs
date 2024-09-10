using E_Accounting.Application.Features.MasterFeatures.UserAndCompanyRelationShipFeatures.Commands.Update;
using E_Accounting.Application.Services.UserAndCompanyRelationShipService;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.BackEnd.UnitTest.Features.AppFeature.AppFeatureUsers.UserAndCompanyRelationShipFeature
{
    public sealed class UpdateUserAndCompanyRelationShipUnitTest
    {
        private readonly Mock<IUserAndCompanyRelationShipService> _service;

        public UpdateUserAndCompanyRelationShipUnitTest()
        {
            _service = new();
        }

        [Fact]
        public async Task CheckedEntityShouldNotBeNull()
        {
             _service.Setup(x => x.GetByIdAsync(It.IsAny<string>(), default)).ReturnsAsync(new Domain.Entities.App_Entites.UserAndCompanyRelationShip()).ShouldNotBeNull();
        }

        [Fact]
        public async Task UpdateUserAndCompanyRelationShipCommandResponseShouldNotBeNull()
        {
            UpdateUserAndCompanyRelationShipCommand request = new(Id: "TestId", userId: "TestId", companyId: "TestId");
            UpdateUserAndCompanyRelationShipCommandHandler handler = new(_service.Object);

            _service.Setup(x => x
                                .GetByIdAsync(It.IsAny<string>(), default))
                                .ReturnsAsync(new Domain.Entities.App_Entites.UserAndCompanyRelationShip());

            UpdateUserAndCompanyRelationShipCommandResponse response = await handler.Handle(request, default);
            response.ShouldNotBeNull();
            response.Message.ShouldNotBeEmpty();
        }
    }
}

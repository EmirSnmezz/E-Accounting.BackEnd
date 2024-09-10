using E_Accounting.Application.Features.MasterFeatures.UserAndCompanyRelationShipFeatures.Commands.Create;
using E_Accounting.Application.Services.UserAndCompanyRelationShipService;
using E_Accounting.Domain.Entities.App_Entites;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.BackEnd.UnitTest.Features.AppFeature.AppFeatureUsers.UserAndCompanyRelationShipFeature
{
    public sealed class CreateUserAndCompanyRelationShipUnitTest
    {
        private readonly Mock<IUserAndCompanyRelationShipService> _service;

        public CreateUserAndCompanyRelationShipUnitTest()
        {
            _service = new();
        }

        [Fact]
        public async Task ShouldNotBeNull()
        {
            _service.Setup(x => x
                                .GetByIdAsync(It.IsAny<string>(), default))
                                .ReturnsAsync(new UserAndCompanyRelationShip()).ShouldNotBeNull();
        }

        [Fact]
        public async Task CreateUserAndCompanyRelationShipCommandShouldNotBeNull()
        {
            CreateUserAndCompanyRelationShipCommand request = new(userId: "TestId", companyId: "TestId");
            CreateUserAndCompanyRelationShipCommandHandler handler = new(_service.Object);
            CreateUserAndCompanyRelationShipCommandResponse response = await handler.Handle(request, default);
            response.ShouldNotBeNull();
            response.Message.ShouldNotBeNull();
        }
    }
}

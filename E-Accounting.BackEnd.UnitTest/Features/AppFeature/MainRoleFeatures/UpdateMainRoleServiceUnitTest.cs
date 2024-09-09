using E_Accounting.Application.Features.MasterFeatures.MainRoleFeatures.Commands.UpdateMainRole;
using E_Accounting.Application.Services.MasterService;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.BackEnd.UnitTest.Features.AppFeature.MainRoleFeatures
{
    public class UpdateMainRoleServiceUnitTest
    {
        private readonly Mock<IMainRoleService> _mainRoleService;

        public UpdateMainRoleServiceUnitTest()
        {
            _mainRoleService = new();
        }

        [Fact]
        public async Task MainRoleShoulNotBeNull()
        {
            _mainRoleService.Setup(x => x
                                        .GetByIdAsync(It.IsAny<string>(), default))
                                        .ReturnsAsync(new Domain.Entities.App_Entites.MainRole());
        }
        [Fact]
        public async Task UpdateMainRolesShouldNotBeNull()
        {
            UpdateMainRoleCommand request = new("TestId", "TestTitle");
            UpdateMainRoleCommandHandler handler = new(_mainRoleService.Object);

            _mainRoleService.Setup(x => x
                                      .GetByIdAsync(It.IsAny<string>(), default))
                                      .ReturnsAsync(new Domain.Entities.App_Entites.MainRole());

            UpdateMainRoleCommandResponse response = await handler.Handle(request, default);
            response.ShouldNotBeNull();
            response.Message.ShouldNotBeEmpty();
        }
    }
}

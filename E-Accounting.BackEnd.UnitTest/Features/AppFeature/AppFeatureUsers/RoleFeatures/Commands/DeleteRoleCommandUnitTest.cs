using E_Accounting.Application.Features.Role_Features.Commands.RemoveRole;
using E_Accounting.Application.Services.MasterService;
using E_Accounting.Domain.Entities.App_Entites.Identity;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.BackEnd.UnitTest.Features.AppFeature.AppFeatureUsers.RoleFeatures.Commands
{
    public class DeleteRoleCommandUnitTest
    {
        private readonly Mock<IRoleService> _roleServiceMock;

        public DeleteRoleCommandUnitTest()
        {
            _roleServiceMock = new();
        }

        [Fact]
        public async Task ShouldNotBeNull()
        {
            _roleServiceMock.Setup(x => x
                            .GetByIdAsync(It.IsAny<string>()))
                            .ReturnsAsync(new AppRole("test", "test", "test"));
        }


        [Fact]
        public async Task RemoveRoleCommandResponseShouldNotBeNull()
        {
            RemoveRoleCommand command = new RemoveRoleCommand("TestId");


            _roleServiceMock.Setup(
                            x => x.GetByIdAsync(It.IsAny<string>()))
                            .ReturnsAsync(new AppRole("test", "test", "test"));

            RemoveRoleCommandHandler handler = new RemoveRoleCommandHandler(_roleServiceMock.Object);

            RemoveRoleCommandResponse response = await handler.Handle(command, default);

            response.ShouldNotBeNull();
            response.Message.ShouldNotBeEmpty();
        }
       
    }
}

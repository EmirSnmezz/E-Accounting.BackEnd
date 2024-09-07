using E_Accounting.Application.Features.Role_Features;
using E_Accounting.Application.Services.MasterService;
using E_Accounting.Domain.Entities.App_Entites.Identity;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.BackEnd.UnitTest.Features.AppFeature.AppFeatureUsers.RoleFeatures
{
    public sealed class CreateRoleCommandUnitTest
    {
        private readonly Mock<IRoleService> _roleServiceMock;
        public CreateRoleCommandUnitTest()
        {
            _roleServiceMock = new();
        }
        [Fact]
        public async Task AppRoleShouldBeNull()
        {
            AppRole appRole = await _roleServiceMock.Object.GetByUCAFCode("UCAF.Create");
            appRole.ShouldBeNull();
        }

        [Fact]
        public async Task CreateRoleCommandResponseShouldNotBeNull()
        {
            var command = new CreateRoleCommand(
                    Title: "UCAF",
                    Code: "UCAF.Create",
                    Name: "Hesap Planı Kayıt Ekleme"
                );

            var handler = new CreateRoleHandler(_roleServiceMock.Object);

            CreateRoleCommandResponse response = await handler.Handle(command, default);
            response.ShouldNotBeNull();
            response.Message.ShouldNotBeNull();
        }
    }
}

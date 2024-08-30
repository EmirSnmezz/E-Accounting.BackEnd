using E_Accounting.Application.Features.Role_Features.Commands.UpdateRole;
using E_Accounting.Application.Services.MasterService;
using E_Accounting.Domain.Entities.App_Entites.Identity;
using Moq;
using Shouldly;

namespace E_Accounting.BackEnd.UnitTest.Features.AppFeature.AppFeatureUsers.RoleFeatures.Commands
{
    public sealed class UpdateRoleCommandUnitTest
    {
        private readonly Mock<IRoleService> _roleServiceMock;

        public UpdateRoleCommandUnitTest()
        {
            _roleServiceMock = new();
        }

        [Fact]
        public async Task AppRoleShouldNotBeNull()
        {
            var result = _roleServiceMock.Setup(x => x.GetByIdAsync(It.IsAny<string>())).ReturnsAsync(new AppRole());
        }

        //[Fact]
        //public async Task UpdateRoleCommandResponseShouldBeNotNull()
        //{

        //}
    }
}

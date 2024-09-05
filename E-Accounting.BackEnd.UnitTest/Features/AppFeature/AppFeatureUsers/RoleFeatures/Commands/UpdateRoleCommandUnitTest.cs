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
            var result = _roleServiceMock.
                                          Setup(x => x.
                                          GetByIdAsync(It.IsAny<string>()))
                                          .ReturnsAsync(new AppRole("test", "test", "test"));
        }

        [Fact]
        public async Task AppRoleCodeShouldBeUniqe()
        {
            AppRole checkRoleCode = await _roleServiceMock.Object.GetByUCAFCode("UCAF.Create");
            checkRoleCode.ShouldBeNull(); // ShouldBeNull methodu, bir değerin boş olması gerektiğini, ShouldNotBeNull ise bir değerin boş olmaması gerektiğini söyler.
        }

        [Fact]
        public async Task UpdateRoleCommandResponseShouldNotBeNull()
        {
            var command = new UpdateRoleCommand("Hesap Planı Kaydı Test", "afc50813-66e7-438f-aed1-e53427c5d96c", "UCAF.Create");
            _roleServiceMock.Setup(x => x 
                            .GetByIdAsync(It.IsAny<string>()))    /// Setup ile bir db ye bağlanıp veri varmış gibi yapıp null hatasını atlattık
                            .ReturnsAsync(new AppRole("test", "test", "test")); 

            UpdateRoleCommandHandler handler = new UpdateRoleCommandHandler(_roleServiceMock.Object);
            UpdateRoleCommandResponse response = await handler.Handle(command, default);
            response.ShouldNotBeNull();
            response.Message.ShouldNotBeEmpty();
        }
    }
}

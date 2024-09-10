using E_Accounting.Application.Features.MasterFeatures.MainRoleFeatures.Commands.RemoveMainRole;
using E_Accounting.Application.Services.MasterService;
using Moq;
using Shouldly;
namespace E_Accounting.BackEnd.UnitTest.Features.AppFeature.AppFeatureUsers.MainRoleFeatures
{
    public class RemoveByIdMainRoleUnitTest
    {
        private readonly Mock<IMainRoleService> _mainRoleService;

        public RemoveByIdMainRoleUnitTest()
        {
            _mainRoleService = new();
        }

        [Fact]
        public async Task RemoveMainRoleCommandResponseShouldNotBeNull()
        {
            var command = new RemoveMainRoleCommand("TestId");
            var handler = new RemoveMainRoleCommandHandler(_mainRoleService.Object);
            var response = await handler.Handle(command, default);

            response.ShouldNotBeNull();
            response.Message.ShouldNotBeEmpty();
        }
    }
}

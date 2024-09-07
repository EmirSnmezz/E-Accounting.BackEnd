using E_Accounting.Application.Features.MasterFeatures.MainRoleFeatures.Commands.CreateMainRole;
using E_Accounting.Application.Features.MasterFeatures.MainRoleFeatures.Commands.CreateRole;
using E_Accounting.Application.Services.MasterService;
using E_Accounting.Domain.Entities.App_Entites;
using Moq;
using Shouldly;

namespace E_Accounting.BackEnd.UnitTest.Features.AppFeature.MainFeatures;
public sealed class CreateMainRoleUnitTest
    {
        private readonly Mock<IMainRoleService> _mainRoleSerivce;
        public CreateMainRoleUnitTest()
        {
            _mainRoleSerivce = new();
        }
    [Fact]
    public async Task MainRoleShouldBeNull()
    {
        MainRole mainRole = await _mainRoleSerivce.Object.GetByTitleAndCompanyId("TestTitle", "TestId", default);
        mainRole.ShouldBeNull();
    }

    [Fact]
    public async Task CreateMainRoleCommandResponseShouldNotBeNull()
    {
        var command = new CreateMainRoleCommand("TestTitle");
        var handler = new CreateMainRoleCommandHandler(_mainRoleSerivce.Object);
        var response = handler.Handle(command, default);
        await response.ShouldNotBeNull();
    }
}

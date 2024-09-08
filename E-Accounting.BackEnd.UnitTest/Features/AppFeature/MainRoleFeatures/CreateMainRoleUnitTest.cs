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
        var command = new CreateMainRoleCommand(
            Title : "Admin",
            CompanyId : "7f816504-eb8f-44c2-a3a1-c77afc943971");
        var handler = new CreateMainRoleCommandHandler(_mainRoleSerivce.Object);
        var response = await  handler.Handle(command, default);
         response.ShouldNotBeNull();
        response.Message.ShouldNotBeEmpty();
       
    }
}

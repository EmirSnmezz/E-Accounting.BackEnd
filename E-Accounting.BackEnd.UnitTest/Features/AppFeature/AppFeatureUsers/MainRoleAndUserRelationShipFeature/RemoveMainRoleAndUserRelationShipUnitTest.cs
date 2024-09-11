using E_Accounting.Application.Features.MasterFeatures.MainRoleAndUserRelationShipFeatures.Command.Remove;
using E_Accounting.Application.Services.MainRoleAndUserRelationShipService;
using Moq;
using Shouldly;

namespace E_Accounting.BackEnd.UnitTest.Features.AppFeature.AppFeatureUsers.MainRoleAndUserRelationShipFeature;
public sealed class RemoveMainRoleAndUserRelationShipUnitTest
{
    private readonly Mock<IMainRoleAndUserRelationShipService> _service;

    public RemoveMainRoleAndUserRelationShipUnitTest()
    {
        _service = new();
    }

    [Fact]
    public async Task MainRoleAndUserRelationShipEntityShouldNotBeNull()
    {
        _service.Setup(x => x
        .GetById(It.IsAny<string>()))
        .ReturnsAsync(new Domain.Entities.App_Entites.MainRoleAndUserRelationShip())
        .ShouldNotBeNull();
    }

    [Fact]
    public async Task RemoveMainRoleAndUserRelationShipCommandResponseShouldNotBeNull()
    {
        RemoveMainRoleAndUserRelationShipCommand request = new(Id: "TestId");
        RemoveMainRoleAndUserRelationShipCommandHandler handler = new(_service.Object);

        _service.Setup(x => x
       .GetById(It.IsAny<string>()))
       .ReturnsAsync(new Domain.Entities.App_Entites.MainRoleAndUserRelationShip())
       .ShouldNotBeNull();

        RemoveMainRoleAndUserRelationShipCommandResponse response = await handler.Handle(request, default);

        response.ShouldNotBeNull();
        response.Message.ShouldNotBeEmpty();
    }
}
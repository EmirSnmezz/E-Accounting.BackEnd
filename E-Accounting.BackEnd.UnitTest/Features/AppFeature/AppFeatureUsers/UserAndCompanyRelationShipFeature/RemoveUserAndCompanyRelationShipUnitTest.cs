using E_Accounting.Application.Features.MasterFeatures.UserAndCompanyRelationShipFeatures.Commands.Remove;
using E_Accounting.Application.Services.UserAndCompanyRelationShipService;
using Moq;
using Shouldly;

namespace E_Accounting.BackEnd.UnitTest.Features.AppFeature.AppFeatureUsers.UserAndCompanyRelationShipFeature;

public sealed record RemoveUserAndCompanyRelationShipUnitTest
{
    private readonly Mock<IUserAndCompanyRelationShipService> _service;

    public RemoveUserAndCompanyRelationShipUnitTest()
    {
        _service = new();
    }

    [Fact]
    public async Task EntityForDeleteShouldNotBeNull()
    {
        _service.Setup(x => x
        .GetByIdAsync(It.IsAny<string>(), default))
        .ReturnsAsync(new Domain.Entities.App_Entites.UserAndCompanyRelationShip())
        .ShouldNotBeNull();
    }

    [Fact]
    public async Task RemoveUserAndCompanyRelationShipCommandResponseShouldNotBeNull()
    {
        RemoveUserAndCompanyRelationShipCommand request = new("TestId");
        RemoveUserAndCompanyRelationShipCommandHandler handler = new(_service.Object);

        _service.Setup(x => x
    .GetByIdAsync(It.IsAny<string>(), default))
    .ReturnsAsync(new Domain.Entities.App_Entites.UserAndCompanyRelationShip())
    .ShouldNotBeNull();

        RemoveUserAndCompanyRelationShipCommandResponse response = await handler.Handle(request, default);
        response.ShouldNotBeNull();
        response.Message.ShouldNotBeEmpty();
    }
}

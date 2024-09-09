using E_Accounting.Application.Features.MasterFeatures.CompanyFeatures.Commands.UpdateCompany;
using E_Accounting.Application.Services.MasterService;
using Moq;
using Shouldly;

namespace E_Accounting.BackEnd.UnitTest.Features.CompanyFeatures;
public sealed class UpdateCompanyCommandUnitTest
{
    private readonly Mock<ICompanyService> _companyService;

    public UpdateCompanyCommandUnitTest()
    {
        _companyService = new();
    }

    [Fact]
    public async Task CompanyShouldNotBeNull()
    {
        _companyService.Setup(x => x
                            .GetById(It.IsAny<string>()))
                            .ReturnsAsync(new Domain.Entities.App_Entites.Company());
    }

    public async Task UpdateCompanyShouldNotBeNull()
    {
        UpdateCompanyCommand request = new(
            Id: "TestId",
            Name: "TestName",
            DatabaseName : "TestDbName",
            ServerName: "TestServerName",
            UserId : "TestUserId",
            Password : "TestPassword"
            );

        UpdateCompanyCommandHandler handler = new(_companyService.Object);

        _companyService.Setup(x => x
                            .GetById(It.IsAny<string>()))
                            .ReturnsAsync(new Domain.Entities.App_Entites.Company());

        UpdateCompanyCommandResponse response = await handler.Handle(request, default);
        response.ShouldNotBeNull();
        response.Message.ShouldNotBeEmpty();
    }

}

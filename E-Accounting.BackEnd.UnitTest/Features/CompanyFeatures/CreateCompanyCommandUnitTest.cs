using E_Accounting.Application.Features.MasterFeatures.CompanyFeatures.Commands.CreateCompany;
using E_Accounting.Application.Services.MasterService;
using E_Accounting.Domain.Entities.App_Entites;
using Moq;
using Shouldly;

namespace E_Accounting.BackEnd.UnitTest.Features.CompanyFeatures
{
    public sealed class CreateCompanyCommandUnitTest
    {
        private readonly Mock<ICompanyService> _companyService;

        public CreateCompanyCommandUnitTest()
        {
            _companyService = new();
        }

        [Fact]
        public async Task CompanyShouldBeNull()
        {
            Company company = (await _companyService.Object.GetCompanyByName("TestCompany", default))!;
            company.ShouldBeNull();
        }

        [Fact]
        public async Task CreateCompanyCommandResponseShouldNotBeNull()
        {
            var command = new CreateCompanyCommand(Name: "DkMotorss",
                                                   ServerName: "TestServer",
                                                   DatabaseName: "TestName",
                                                   UserId: "TestUsers",
                                                   Password: "TestPassword");

            var handler = new CreateCompanyCommandHandler(_companyService.Object);

            CreateCompanyCommandResponse response = await handler.Handle(command, default);
            response.ShouldNotBeNull();
            response.Message.ShouldNotBeEmpty();


        }
    }


}



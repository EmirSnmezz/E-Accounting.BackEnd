using E_Accounting.Application.Features.MasterFeatures.CompanyFeatures.Commands.DeleteCompany;
using E_Accounting.Application.Services.MasterService;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.BackEnd.UnitTest.Features.CompanyFeatures.UCAFFeatures;
public class RemoveCompanyCommandUnitTest
{
    private readonly Mock<ICompanyService> _companyService;

    public RemoveCompanyCommandUnitTest()
    {
        _companyService = new();
    }

    [Fact]
    public async Task RemoveCompanyShouldNotBeNull()
    {
        DeleteCompanyCommand command = new("TestId");
        DeleteCompanyCommandHandler handler = new(_companyService.Object);

        _companyService.Setup(x => x.GetById(It.IsAny<string>()));

        DeleteCompanyCommandResponse response =  await handler.Handle(command, default);

        response.ShouldNotBeNull();
        response.Message.ShouldNotBeEmpty();
    }
}

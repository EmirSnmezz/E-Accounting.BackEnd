using E_Accounting.Application.Features.CompanyFeatures.UCAFFeautres.Commands.UpdateUCAF;
using E_Accounting.Application.Services.CompanyService;
using E_Accounting.Domain.Entities.CompanyEntities;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.BackEnd.UnitTest.Features.CompanyFeatures.UCAFFeatures
{
    public sealed class UpdateUCAFCommandUnitTest
    {
        private readonly Mock<IUCAFService> ucafService;

        public UpdateUCAFCommandUnitTest()
        {
            ucafService = new();
        }

        [Fact]
        public async Task CheckUCAFForUpdateCommandGetByIdShoulNotBeNull()
        {
            ucafService.Setup(x => 
            x.GetByIdAsync(It.IsAny<string>(), It.IsAny<string>()))
            .ReturnsAsync(new Domain.Entities.CompanyEntities.UniformChartOfAccount())
            .ShouldNotBeNull();
        }

        [Fact]
        public async Task CheckUCAFForUpdateCommandGetByCodeShouldNotBeNull()
        {
            ucafService.Setup(x => x.GetByCodeAsync(It.IsAny<string>(), It.IsAny<string>(), default)).ReturnsAsync(new Domain.Entities.CompanyEntities.UniformChartOfAccount()).ShouldNotBeNull();
        }

        [Fact]
        public async Task CheckCodeForUCAFUpdateCommandGetByCodeShoulNotBeNul()
        {
            UpdateUCAFCommand ucaf = new(
                CompanyId: "testId",
                Id: Guid.NewGuid().ToString(),
                Name: "Merkez Kasa",
                Code: "100.01.001",
                Type: "M");

            await CheckUCAFForUpdateCommandGetByIdShoulNotBeNull();

            UpdateUCAFCommandHandler handler = new UpdateUCAFCommandHandler(ucafService.Object);

            UpdateUCAFCommandResponse response = await handler.Handle(ucaf, default);

            response.ShouldNotBeNull();
            response.Message.ShouldNotBeEmpty();

        }
    }
}

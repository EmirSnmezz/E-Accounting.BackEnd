using E_Accounting.Application.Features.Company_Features.UCAFFeautres.Commands.CreateUCAF;
using E_Accounting.Application.Features.CompanyFeatures.UCAFFeautres.Commands.RemoveUCAF;
using E_Accounting.Application.Services.CompanyService;
using E_Accounting.Domain.Entities.CompanyEntities;
using E_Accounting.Persistance.Service.CompanyService;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.BackEnd.UnitTest.Features.CompanyFeatures.UCAFFeatures
{
    public sealed class RemoveUCAFCommandUnitTest
    {
        private readonly Mock<IUCAFService> ucafService;

        public RemoveUCAFCommandUnitTest()
        {
            ucafService = new();
        }

        [Fact]  
        public async Task CheckRemoveByIdUcafIsGroupAndAviableShouldBeTrue()
        {
            ucafService.Setup(x =>
            x.CheckRemoveByIdUcafIsGroupAndAvailable
            (It.IsAny<string>(),
            It.IsAny<string>()))
            .ReturnsAsync(true);
        }


        [Fact]
        public async Task UCAFShouldNotBeNullFoRemoveByIdUcafAsync()
        {
            ucafService.Setup(x => 
                x.GetByIdAsync(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(new UniformChartOfAccount())
                .ShouldNotBeNull();
        }

        [Fact]
        public async Task RemoveByIdUcafAsyncCommandResponseShouldNotBeNull()
        {
            RemoveUCAFCommand command = new("testId", "TestCompanyId");
            var checkIfAvaiblable = ucafService.Object.CheckRemoveByIdUcafIsGroupAndAvailable(command.id, command.companyId);

            RemoveUCAFCommandHandler handler = new(ucafService.Object);
           

            ucafService.Setup(x =>
           x.CheckRemoveByIdUcafIsGroupAndAvailable
           (It.IsAny<string>(),
           It.IsAny<string>()))
           .ReturnsAsync(true);

            RemoveUCAFCommandResponse Response = await handler.Handle(command, default);
            Response.ShouldNotBeNull();
            Response.Message.ShouldNotBeEmpty();

        }
    }
}

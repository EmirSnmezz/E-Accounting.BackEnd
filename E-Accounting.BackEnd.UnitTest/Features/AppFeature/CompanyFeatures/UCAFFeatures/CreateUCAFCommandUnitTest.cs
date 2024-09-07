using E_Accounting.Application.Features.Company_Features.UCAFFeautres.Commands.CreateUCAF;
using E_Accounting.Application.Services.CompanyService;
using E_Accounting.Domain.Entities.CompanyEntities;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.BackEnd.UnitTest.Features.AppFeature.CompanyFeatures.UCAFFeatures
{
    public sealed class CreateUCAFCommandUnitTest
    {
        private readonly Mock<IUCAFService> _ucafService;

        public CreateUCAFCommandUnitTest()
        {
            _ucafService = new();
        }

        [Fact]
        public async Task UCAFShouldBeNull()
        {
            UniformChartOfAccount ucaf = await _ucafService.Object.GetByCode(It.IsAny<string>(), default);
            ucaf.ShouldBeNull();
        }

        [Fact]
        public async Task CreateUCAFCommandResponseShouldNotBeNull()
        {
            CreateUCAFCommand command = new CreateUCAFCommand("TestId", "TestName", "TestType", "Test");
            CreateUCAFCommandHandler handler = new CreateUCAFCommandHandler(_ucafService.Object);
            CreateUCAFCommandResponse respone = await handler.Handle(command, default);
            respone.ShouldNotBeNull();
            respone.Message.ShouldNotBeEmpty();
        }
    }
}

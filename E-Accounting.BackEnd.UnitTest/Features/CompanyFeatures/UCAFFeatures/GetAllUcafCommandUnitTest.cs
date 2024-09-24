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
    public sealed class GetAllUcafCommandUnitTest
    {
        private readonly Mock<IUCAFService> ucafService;

        public GetAllUcafCommandUnitTest()
        {
            ucafService = new();
        }

        [Fact]
        public async Task GetAllCommandResponseShouldNotBeNull()
        {
            ucafService.Setup(x => 
            x.GetAllAsync(It.IsAny<string>()))
            .ReturnsAsync(new List<UniformChartOfAccount>().AsQueryable())
            .ShouldNotBeNull();
        }
    }
}

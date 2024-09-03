using E_Accounting.Application.Features.Role_Features.Queries.GetAllRoles;
using E_Accounting.Application.Services.MasterService;
using E_Accounting.Domain.Entities.App_Entites.Identity;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.BackEnd.UnitTest.Features.AppFeature.AppFeatureUsers.RoleFeatures.Queries
{
    public sealed class GetAllRolesQueryUnitTest
    {
        private readonly Mock<IRoleService> _roleServiceMock;

        public GetAllRolesQueryUnitTest()
        {
            _roleServiceMock = new();
        }

        [Fact]
        public async Task GetAllRolesQueryResponseQueryNotBeNull()
        {
            _roleServiceMock.Setup(x => x.GettAllRolesAsync()).ReturnsAsync(new List<AppRole>().AsQueryable());
        }
    }
}

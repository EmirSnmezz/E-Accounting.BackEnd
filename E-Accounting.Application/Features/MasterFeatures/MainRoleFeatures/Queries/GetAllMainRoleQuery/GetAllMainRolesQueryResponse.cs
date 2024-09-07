using E_Accounting.Domain.Entities.App_Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Application.Features.MasterFeatures.MainRoleFeatures.Queries.GetAllMainRoleQuery
{
    public record GetAllMainRolesQueryResponse
        (
            List<MainRole> MainRoles
        );
}

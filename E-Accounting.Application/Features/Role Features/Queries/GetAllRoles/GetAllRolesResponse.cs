using E_Accounting.Domain.Entities.App_Entites.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Application.Features.Role_Features.Queries.GetAllRoles
{
    public class GetAllRolesResponse
    {
        public IList<AppRole> Roles { get; set; }
    }
}

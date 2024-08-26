using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Application.Features.Role_Features
{
    public class CreateRoleRequest: IRequest<CreateRoleResponse>
    {
        public string Name { get; set; }
    }
}

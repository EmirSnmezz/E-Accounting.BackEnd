using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Application.Features.Role_Features.Commands.RemoveRole
{
    public record RemoveRoleCommandResponse
        (
            string Message = "Role Silme İşlemi Başarılı !"
        );
}

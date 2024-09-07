using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Application.Features.MasterFeatures.MainRoleFeatures.Commands.CreateStaticRoles
{
    public sealed record CreateStaticMainRolesCommandResponse
        (
            string Message = "Tüm Static MainRole'lerin Kaydı Başarıyla Tamamlandı!"
        );
}

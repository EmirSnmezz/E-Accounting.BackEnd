using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Application.Features.MasterFeatures.MainRoleFeatures.Commands.CreateRole
{
    public sealed record CreateMainRoleCommandResponse(
        string Message = "MainRole Kaydı Başarılı!");
}

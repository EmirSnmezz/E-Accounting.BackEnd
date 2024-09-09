using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Application.Features.MasterFeatures.MainRoleFeatures.Commands.RemoveMainRole;
    public sealed record RemoveMainRoleCommandResponse
    (
        string Message = "Main Role Başarıyla Silindi."
    );

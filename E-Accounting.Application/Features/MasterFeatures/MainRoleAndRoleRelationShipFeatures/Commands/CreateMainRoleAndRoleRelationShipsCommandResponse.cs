using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Application.Features.MasterFeatures.MainRoleAndRoleRelationShipFeatures.Commands;
    public sealed record CreateMainRoleAndRoleRelationShipsCommandResponse
    (
        string Message = "Role İlişki Kaydı Başarılı"
    );

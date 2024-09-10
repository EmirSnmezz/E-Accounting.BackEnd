using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Application.Features.MasterFeatures.MainRoleAndRoleRelationShipFeatures.Commands.Remove;
    public sealed record RemoveMainRoleAndRoleRelationShipCommandResponse
    (
        string Message = "İlgil Role İlişkisi Başarıyla Silindi"
    );

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Application.Features.MasterFeatures.MainRoleAndUserRelationShipFeatures.Command.Remove;
    public sealed record RemoveMainRoleAndUserRelationShipCommandResponse
    (
        string Message = "Kullanıcı MailRole İlişkisi Başarıyla Kaldırıldı"
    );

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Application.Features.MasterFeatures.UserAndCompanyRelationShipFeatures.Commands.Create;

    public sealed record CreateUserAndCompanyRelationShipCommandResponse
    (
        string Message = "Kullanıcı İle Şirket Başarıyla İlişkilendirildi"
    );
    


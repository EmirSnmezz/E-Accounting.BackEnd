﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Application.Features.MasterFeatures.MainRoleAndRoleRelationShipFeatures.Commands.Update;
    public sealed record UpdateMainRoleAndRoleRelationShipCommandResponse(
            string Message = "Role İlişkisi Başarıyla Güncellendi"
        );

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Application.Features.MasterFeatures.CompanyFeatures.Commands.CreateCompany
{
    public record CreateCompanyCommandResponse
        (
          string Message = "Şirket Kaydı Başarıyla Tamamlandı!"
        );
}

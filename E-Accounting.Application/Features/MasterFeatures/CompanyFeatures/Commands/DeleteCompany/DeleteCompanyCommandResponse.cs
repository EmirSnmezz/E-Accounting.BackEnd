using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Application.Features.MasterFeatures.CompanyFeatures.Commands.DeleteCompany;
    public sealed record DeleteCompanyCommandResponse
    ( 
        string Message = "Şirket Başarıyla Silindi"
    );

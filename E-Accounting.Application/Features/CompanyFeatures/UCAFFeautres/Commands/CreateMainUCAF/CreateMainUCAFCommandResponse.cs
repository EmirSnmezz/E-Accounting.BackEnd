using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Application.Features.CompanyFeatures.UCAFFeautres.Commands.CreateMainUCAF
{
    public sealed record CreateMainUCAFCommandResponse(string Message = "Şirketinize ana hesap planı oluşturuldu");
}

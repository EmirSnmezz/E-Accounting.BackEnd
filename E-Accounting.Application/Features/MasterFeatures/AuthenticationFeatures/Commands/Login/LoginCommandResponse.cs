using E_Accounting.Domain.DTOs;
using E_Accounting.Domain.Entities.App_Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Application.Features.MasterFeatures.AuthenticationFeatures.Commands.Login
{
    public record LoginCommandResponse(
        RefreshTokenDto Token,
        string Email,
        string UserId,
        string UserNameAndLastName,
        int Year,
        IList<CompanyDto> Companies,
        CompanyDto Company
        );
}

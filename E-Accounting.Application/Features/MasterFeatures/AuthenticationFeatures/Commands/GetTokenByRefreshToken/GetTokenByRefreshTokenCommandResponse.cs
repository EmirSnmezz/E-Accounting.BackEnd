using E_Accounting.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Application.Features.MasterFeatures.AuthenticationFeatures.Commands.GetTokenByRefreshToken;
    public sealed record GetTokenByRefreshTokenCommandResponse(
        RefreshTokenDto Token,
        string Email,
        string UserId,
        string FirstAndLastName,
        IList<CompanyDto> Companies,
        int Year,
        CompanyDto Company);


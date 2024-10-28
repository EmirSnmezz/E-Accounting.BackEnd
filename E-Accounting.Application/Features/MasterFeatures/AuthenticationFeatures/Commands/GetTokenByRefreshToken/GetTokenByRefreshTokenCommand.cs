using E_Accounting.Application.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace E_Accounting.Application.Features.MasterFeatures.AuthenticationFeatures.Commands.GetTokenByRefreshToken;
    public sealed record class GetTokenByRefreshTokenCommand
        (
        string UserId,
        string RefreshToken,
        string CompanyId
        ) : ICommand<GetTokenByRefreshTokenCommandResponse>;

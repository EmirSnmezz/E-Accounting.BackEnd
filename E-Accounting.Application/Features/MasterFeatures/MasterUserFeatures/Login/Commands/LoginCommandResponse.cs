using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Application.Features.MasterFeatures.MasterUserFeatures.Login.Commands
{
    public record LoginCommandResponse(
        string Token,
        string Email,
        string UserId,
        string UserNameAndLastName);
}

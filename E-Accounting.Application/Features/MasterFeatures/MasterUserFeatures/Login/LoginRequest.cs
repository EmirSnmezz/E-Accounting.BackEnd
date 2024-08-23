using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Application.Features.MasterFeatures.MasterUserFeatures.Login
{
    public class LoginRequest : IRequest<LoginResponse>
    {
        public string EmailOrUserName { get; set; }
        public string Password { get; set; }
    }
}

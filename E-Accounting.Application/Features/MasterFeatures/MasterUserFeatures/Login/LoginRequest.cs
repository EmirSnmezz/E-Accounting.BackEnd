using MediatR;

namespace E_Accounting.Application.Features.MasterFeatures.MasterUserFeatures.Login
{
    public class LoginRequest : IRequest<LoginResponse>
    {
        public string EmailOrUserName { get; set; }
        public string Password { get; set; }
    }
}

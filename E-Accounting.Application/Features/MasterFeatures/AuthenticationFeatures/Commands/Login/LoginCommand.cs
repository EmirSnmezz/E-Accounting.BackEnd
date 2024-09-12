using E_Accounting.Application.Messaging;
using MediatR;

namespace E_Accounting.Application.Features.MasterFeatures.AuthenticationFeatures.Commands.Login
{
    public record LoginCommand
        (
        string EmailOrUserName,
        string Password
        ) : ICommand<LoginCommandResponse>;
}

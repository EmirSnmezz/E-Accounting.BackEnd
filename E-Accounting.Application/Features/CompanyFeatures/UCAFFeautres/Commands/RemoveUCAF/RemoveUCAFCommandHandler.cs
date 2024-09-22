using E_Accounting.Application.Messaging;
using E_Accounting.Application.Services.CompanyService;

namespace E_Accounting.Application.Features.CompanyFeatures.UCAFFeautres.Commands.RemoveUCAF;
public sealed record RemoveUCAFCommandHandler : ICommandHandler<RemoveUCAFCommand, RemoveUCAFCommandResponse>
{
    private readonly IUCAFService _ucafService;

    public RemoveUCAFCommandHandler(IUCAFService ucafService)
    {
        _ucafService = ucafService;
    }
    public async Task<RemoveUCAFCommandResponse> Handle(RemoveUCAFCommand request, CancellationToken cancellationToken)
    {
        await _ucafService.RemoveByIdUcafAsync(request.id, request.companyId);
        return new();
    }
}


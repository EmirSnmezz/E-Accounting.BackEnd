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
        var checkRemoveUcafById = await _ucafService.CheckRemoveByIdUcafIsGroupAndAvailable(request.id, request.companyId);

        if(!checkRemoveUcafById)
        {
            throw new Exception("Hesap Planına Bağlı Alt Hesaplar Olduğundan Bu Hesap Plan Kaydı Silinememektedir.");
        }
        await _ucafService.RemoveByIdUcafAsync(request.id, request.companyId);
        return new();
    }
}


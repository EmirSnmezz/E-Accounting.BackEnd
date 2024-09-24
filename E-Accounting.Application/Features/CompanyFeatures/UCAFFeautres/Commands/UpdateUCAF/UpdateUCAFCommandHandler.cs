using E_Accounting.Application.Messaging;
using E_Accounting.Application.Services.CompanyService;
using E_Accounting.Domain.Entities.CompanyEntities;

namespace E_Accounting.Application.Features.CompanyFeatures.UCAFFeautres.Commands.UpdateUCAF;
public sealed record UpdateUCAFCommandHandler : ICommandHandler<UpdateUCAFCommand, UpdateUCAFCommandResponse>
{
    private readonly IUCAFService _ucafService;

    public UpdateUCAFCommandHandler(IUCAFService ucafService)
    {
        _ucafService = ucafService;
    }
    public async Task<UpdateUCAFCommandResponse> Handle(UpdateUCAFCommand request, CancellationToken cancellationToken)
    {
        UniformChartOfAccount result = await _ucafService.GetByIdAsync(request.Id, request.CompanyId);
        if (result == null)
        {
            throw new Exception("Güncellenmek istenen hesap planı kaydına ulaşılamadı. Lütfen sistem yöneticisiyle iletişime geçiniz...");

        }

        if(result.Code == request.Code )
        {
            throw new Exception("Güncellemek İstediğiniz Hesap Planı Mevcut...");
        }

        if(request.Type != "G" && request.Type != "M")
        {
            throw new Exception("Hesap Planı Türü Grup Ya Da Muavin Olmalıdır");
        }

        result.Type = request.Type;
        result.Name = request.Name;
        result.Code = request.Code;
        await _ucafService.UpdateAsync(result, request.CompanyId);
        return new();
    }
}


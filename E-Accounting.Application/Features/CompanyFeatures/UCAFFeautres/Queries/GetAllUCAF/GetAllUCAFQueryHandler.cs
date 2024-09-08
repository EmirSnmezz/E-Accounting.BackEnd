using E_Accounting.Application.Messaging;
using E_Accounting.Application.Services.CompanyService;
using E_Accounting.Domain.Entities.CompanyEntities;
using Microsoft.EntityFrameworkCore;

namespace E_Accounting.Application.Features.CompanyFeatures.UCAFFeautres.Queries.GetAllUCAF;
public class GetAllUCAFQueryHandler : IQueryHandler<GetAllUCAFQuery, GetAllUCAFQueryResponse>
{
    private readonly IUCAFService _ucafService;
    public GetAllUCAFQueryHandler(IUCAFService ucafService)
    {
        _ucafService = ucafService;        
    }

    public async Task<GetAllUCAFQueryResponse> Handle(GetAllUCAFQuery request, CancellationToken cancellationToken)
    {
        IList<UniformChartOfAccount> ucafs = await _ucafService.GetAll().ToListAsync();

        if (ucafs == null)
        {
            throw new Exception("Görüntülenecek Hesap Planı Kaydı Bulunamadı");
        }

        return new(ucafs.AsQueryable());
    }
}

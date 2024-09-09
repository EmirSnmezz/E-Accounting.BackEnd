using E_Accounting.Application.Messaging;
using E_Accounting.Application.Services.MasterService;
using E_Accounting.Domain.Entities.App_Entites;

namespace E_Accounting.Application.Features.MasterFeatures.CompanyFeatures.Commands.UpdateCompany;
public sealed class UpdateCompanyCommandHandler : ICommandHandler<UpdateCompanyCommand, UpdateCompanyCommandResponse>
{
    private readonly ICompanyService _companyService;

    public UpdateCompanyCommandHandler(ICompanyService companyService)
    {
        _companyService = companyService;
    }
    public async Task<UpdateCompanyCommandResponse> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
    {
        Company? company = await _companyService.GetById(request.Id);

        if (company == null)
        {
            throw new Exception("Güncellenmek istenen şirket bilgisine ulaşılamadı");
        }

        if(company.Name == request.Name)
        {
            throw new Exception("Aynı isimde şirket kaydı zaten mevcut");
        }

        company.Name = request.Name;
        company.ServerName = request.ServerName;
        company.DatabaseName = request.DatabaseName;
        company.ServerUserId = request.UserId;
        company.ServerPassword = request.Password;

        await _companyService.UpdateAsync(company);

        return new();

    }
}

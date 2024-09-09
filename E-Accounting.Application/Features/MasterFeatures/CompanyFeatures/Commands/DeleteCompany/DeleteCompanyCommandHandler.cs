using E_Accounting.Application.Messaging;
using E_Accounting.Application.Services.MasterService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Application.Features.MasterFeatures.CompanyFeatures.Commands.DeleteCompany;
public class DeleteCompanyCommandHandler : ICommandHandler<DeleteCompanyCommand, DeleteCompanyCommandResponse>
{
    private readonly ICompanyService _companyService;

    public DeleteCompanyCommandHandler(ICompanyService companyService)
    {
        _companyService = companyService;
    }

    public async Task<DeleteCompanyCommandResponse> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
    {
       await _companyService.RemoveByIdAsync(request.Id);
        return new();
    }
}

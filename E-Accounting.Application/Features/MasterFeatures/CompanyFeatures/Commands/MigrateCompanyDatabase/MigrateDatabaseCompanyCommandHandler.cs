using E_Accounting.Application.Messaging;
using E_Accounting.Application.Services.MasterService;

namespace E_Accounting.Application.Features.MasterFeatures.CompanyFeatures.Commands.MigrateCompanyDatabase
{
    public sealed class MigrateDatabaseCompanyCommandHandler : ICommandHandler<MigrateDatabaseCommand, MigrateDatabaseCommandResponse>
    {
        private readonly ICompanyService _companyService;
        public MigrateDatabaseCompanyCommandHandler(ICompanyService service)
        {
            _companyService = service;
        }
        public async Task<MigrateDatabaseCommandResponse> Handle(MigrateDatabaseCommand request, CancellationToken cancellationToken)
        {
            await _companyService.MigrateCompanyDatabase();
            return new();
        }

    }
}

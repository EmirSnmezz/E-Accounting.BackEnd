using E_Accounting.Application.Messaging;
using E_Accounting.Application.Services.CompanyService;

namespace E_Accounting.Application.Features.CompanyFeatures.UCAFFeautres.Commands.CreateMainUCAF
{
    public sealed class CreateMainUCAFHandler : ICommandHandler<CreateMainUCAFCommand, CreateMainUCAFCommandResponse>
    {
        private readonly IUCAFService _ucafService;

        public CreateMainUCAFHandler( IUCAFService ucafService )
        {
            _ucafService = ucafService;
        }
        public async Task<CreateMainUCAFCommandResponse> Handle(CreateMainUCAFCommand request, CancellationToken cancellationToken)
        {
            await _ucafService.CreateMainUCAFsToCompany(request.companyId, cancellationToken);
            return new();
        }
    }
}

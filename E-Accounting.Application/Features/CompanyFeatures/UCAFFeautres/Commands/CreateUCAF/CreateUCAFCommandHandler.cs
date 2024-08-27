using E_Accounting.Application.Messaging;
using E_Accounting.Application.Services.CompanyService;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace E_Accounting.Application.Features.Company_Features.UCAFFeautres.Commands.CreateUCAF
{
    public sealed class CreateUCAFCommandHandler :ICommandHandler<CreateUCAFCommand, CreateUCAFCommandResponse>
    {
        private readonly IUCAFService _ucafService;

        public CreateUCAFCommandHandler(IUCAFService ucafService)
        {
            _ucafService = ucafService;
        }
        public async Task<CreateUCAFCommandResponse> Handle(CreateUCAFCommand request, CancellationToken cancellationToken)
        {
            await _ucafService.CreateUcafAsync(request);
            return new();
        }
    }
}

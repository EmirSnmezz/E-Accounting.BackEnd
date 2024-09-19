﻿using E_Accounting.Application.Messaging;
using E_Accounting.Application.Services.CompanyService;
using E_Accounting.Domain.Entities.CompanyEntities;

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
            UniformChartOfAccount UCAF = await _ucafService.GetByCodeAsync(request.CompanyId, request.Code, cancellationToken);

            if (UCAF != null)
            {
                throw new Exception("İlgili Koda Sahip Hesap Kaydı Kayıt İşlemi Daha Önce Gerçekleştirilmiş..");
            }
            await _ucafService.CreateUcafAsync(request, cancellationToken);
            return new();
        }
    }
}

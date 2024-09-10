using E_Accounting.Domain.Entities.App_Entites;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Application.Features.MasterFeatures.UserAndCompanyRelationShipFeatures.Commands.Create;
public sealed class CreateUserAndCompanyRelationShipCommandValidator : AbstractValidator<UserAndCompanyRelationShip>
{
    public CreateUserAndCompanyRelationShipCommandValidator()
    {
        RuleFor(x => x.CompanyId).NotNull().WithMessage("Şirket Bilgisi Boş Geçilemez");
        RuleFor(x => x.CompanyId).NotEmpty().WithMessage("Şirket Bilgisi Boş Geçilemez");
        RuleFor(x => x.MasterUserId).NotNull().WithMessage("Kullanıcı Bilgisi Boş Geçilemez");
        RuleFor(x => x.MasterUserId).NotEmpty().WithMessage("Kullanıcı Bilgisi Boş Geçilemez");
    }
}

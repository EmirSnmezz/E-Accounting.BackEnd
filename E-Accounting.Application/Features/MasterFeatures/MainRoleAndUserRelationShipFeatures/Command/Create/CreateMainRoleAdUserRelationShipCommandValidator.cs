using E_Accounting.Domain.Entities.App_Entites;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Application.Features.MasterFeatures.MainRoleAndUserRelationShipFeatures.Command.Create
{
    public sealed class CreateMainRoleAdUserRelationShipCommandValidator : AbstractValidator<MainRoleAndUserRelationShip>
    {
        public CreateMainRoleAdUserRelationShipCommandValidator()
        {
            RuleFor(x => x.UserId).NotNull().WithMessage("Kullanıcı Bilgisi Boş Geçilemez");
            RuleFor(x => x.UserId).NotEmpty().WithMessage("Kullanıcı Bilgisi Boş Geçilemez");
            RuleFor(x => x.MainRoleId).NotNull().WithMessage("MainRole Bilgisi Boş Geçilememz");
            RuleFor(x => x.MainRoleId).NotEmpty().WithMessage("MainRole Bilgisi Boş Geçilememz");
            RuleFor(x => x.CompanyId).NotNull().WithMessage("Şirket Bilgisi Boş Geçilemez");
            RuleFor(x => x.CompanyId).NotEmpty().WithMessage("Şirket Bilgisi Boş Geçilemez");
        }
    }
}

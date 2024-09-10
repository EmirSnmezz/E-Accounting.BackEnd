using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Application.Features.MasterFeatures.MainRoleAndRoleRelationShipFeatures.Commands.Update
{
    public sealed class UpdateMainRoleAndRoleRelationShipCommandValidator : AbstractValidator<UpdateMainRoleAndRoleRelationShipCommand>
    {
        public UpdateMainRoleAndRoleRelationShipCommandValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Lütfen Güncellemek İstediğiniz İlişkiyi Seçiniz");
            RuleFor(x => x.Id).NotEmpty().WithMessage("Lütfen Güncellemek İstediğiniz İlişkiyi Seçiniz");
            RuleFor(x => x.RoleId).NotNull().WithMessage("Role Id Alanı Boş Geçilemez");
            RuleFor(x => x.RoleId).NotEmpty().WithMessage("Role Id Alanı Boş Geçilemez");
            RuleFor(x => x.MainRoleId).NotNull().WithMessage("Main Role Id Alanı Boş Geçilemez");
            RuleFor(x => x.MainRoleId).NotEmpty().WithMessage("Main Role Id Alanı Boş Geçilemez");
        }
    }
}

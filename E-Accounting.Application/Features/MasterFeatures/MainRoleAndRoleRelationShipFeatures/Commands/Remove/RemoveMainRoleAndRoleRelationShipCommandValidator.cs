using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Application.Features.MasterFeatures.MainRoleAndRoleRelationShipFeatures.Commands.Remove
{
    public sealed class RemoveMainRoleAndRoleRelationShipCommandValidator : AbstractValidator<RemoveMainRoleAndRoleRelationShipCommand>
    {
        public RemoveMainRoleAndRoleRelationShipCommandValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Lütfen Sileceğiniz İlişkiyi Seçiniz");
            RuleFor(x => x.Id).NotEmpty().WithMessage("Lütfen Sileceğiniz İlişkiyi Seçiniz");
        }
    }
}

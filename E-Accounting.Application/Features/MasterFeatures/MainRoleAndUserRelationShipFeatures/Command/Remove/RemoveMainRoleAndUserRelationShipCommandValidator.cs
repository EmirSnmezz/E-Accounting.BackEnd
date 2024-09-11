using E_Accounting.Domain.Entities.App_Entites;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Application.Features.MasterFeatures.MainRoleAndUserRelationShipFeatures.Command.Remove
{
    public sealed class RemoveMainRoleAndUserRelationShipCommandValidator : AbstractValidator<RemoveMainRoleAndUserRelationShipCommand>
    {
        public RemoveMainRoleAndUserRelationShipCommandValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Lütfen Silmek İstediğiniz Rolü Seçin");
            RuleFor(x => x.Id).NotEmpty().WithMessage("Lütfen Silmek İstediğiniz Rolü Seçin");
        }
    }
}

using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Application.Features.MasterFeatures.MainRoleAndRoleRelationShipFeatures.Commands
{
    public class CreateMainRoleAndRoleCommandValidator : AbstractValidator<CreateMainRoleAndRoleRelationShipCommand>
    {
        public CreateMainRoleAndRoleCommandValidator()
        {
            RuleFor(x => x.RoleId).NotEmpty().WithMessage(("Role Seçilmelidir."));
            RuleFor(x => x.RoleId).NotNull().WithMessage(("Role Seçilmelidir."));
            RuleFor(x => x.MainRoleId).NotEmpty().WithMessage(("MainRole Seçilmelidir."));
            RuleFor(x => x.MainRoleId).NotNull().WithMessage(("MainRole Seçilmelidir."));
        }
    }
}

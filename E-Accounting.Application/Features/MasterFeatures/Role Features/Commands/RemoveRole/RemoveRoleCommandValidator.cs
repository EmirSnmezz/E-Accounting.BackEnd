using E_Accounting.Application.Features.Role_Features.Commands.RemoveRole;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Application.Features.CompanyFeatures.Role_Features.Commands.RemoveRole
{
    public sealed class RemoveRoleCommandValidator : AbstractValidator<RemoveRoleCommand>
    {
        public RemoveRoleCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id Bilgisi Boş Olamaz");
            RuleFor(x => x.Id).NotNull().WithMessage("Id Bilgisi Boş Olamaz");
        }
    }
}

using E_Accounting.Application.Features.Role_Features.Commands.UpdateRole;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Application.Features.CompanyFeatures.Role_Features.Commands.UpdateRole
{
    public sealed class UpdateRoleCommandValidator : AbstractValidator<UpdateRoleCommand>
    {
        public UpdateRoleCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Role Adı Bilgisi Boş Geçilemez");
            RuleFor(x => x.Name).NotNull().WithMessage(" Role Adı Biligisi Boş Geçilemez");

            RuleFor(x => x.Code).NotEmpty().WithMessage("Role Kodu Bilgisi Boş Geçilemez");
            RuleFor(x => x.Code).NotNull().WithMessage("Role Kodu Bilgisi Boş Geçilemez");
        }
    }
}

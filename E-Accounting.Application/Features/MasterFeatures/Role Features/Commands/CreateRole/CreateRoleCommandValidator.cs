using E_Accounting.Application.Features.Role_Features;
using FluentValidation;

namespace E_Accounting.Application.Features.CompanyFeatures.Role_Features.Commands.CreateRole
{
    public sealed class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
    {
        public CreateRoleCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Role Adı Bilgisi Boş Geçilemez");
            RuleFor(x => x.Name).NotNull().WithMessage(" Role Adı Biligisi Boş Geçilemez");

            RuleFor(x => x.Code).NotEmpty().WithMessage("Role Kodu Bilgisi Boş Geçilemez");
            RuleFor(x => x.Code).NotNull().WithMessage("Role Kodu Bilgisi Boş Geçilemez");
        }
    }
}

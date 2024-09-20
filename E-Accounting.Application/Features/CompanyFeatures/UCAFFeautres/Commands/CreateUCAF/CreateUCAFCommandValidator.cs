using E_Accounting.Application.Features.Company_Features.UCAFFeautres.Commands.CreateUCAF;
using FluentValidation;

namespace E_Accounting.Application.Features.CompanyFeatures.UCAFFeautres.Commands.CreateUCAF
{
    public sealed class CreateUCAFCommandValidator : AbstractValidator<CreateUCAFCommand>
    {
        public CreateUCAFCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Hesap Planı Adı Bilgisi Boş Geçilemez");
            RuleFor(x => x.Name).NotNull().WithMessage("Hesap Planı Adı Biligisi Boş Geçilemez");

            RuleFor(x => x.Code).NotEmpty().WithMessage("Hesap Planı Kodu Bilgisi Boş Geçilemez");
            RuleFor(x => x.Code).NotNull().WithMessage("Hesap Planı Kodu Bilgisi Boş Geçilemez");

            RuleFor(x => x.CompanyId).NotEmpty().WithMessage("Şirket Bilgisi Boş Geçilemez");
            RuleFor(x => x.CompanyId).NotNull().WithMessage("Şirket Bilgisi Boş Geçilemez");

            RuleFor(x => x.Type).NotEmpty().WithMessage("Hesap Plan Tipi Boş Olamaz");
            RuleFor(x => x.Type).NotNull().WithMessage("Hesap Plan Tipi Boş Olamaz");
            //RuleFor(x => x.Type).MinimumLength(1).WithMessage("Hesap Plan Tipi 1 Karakter Olmalıdır");

        }
    }
}

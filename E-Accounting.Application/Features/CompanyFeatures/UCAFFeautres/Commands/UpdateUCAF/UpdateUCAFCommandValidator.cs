using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Application.Features.CompanyFeatures.UCAFFeautres.Commands.UpdateUCAF
{
    public sealed class UpdateUCAFCommandValidator : AbstractValidator<UpdateUCAFCommand>
    {
        public UpdateUCAFCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Hesap Planı Adı Boş Geçilemez!");
            RuleFor(x => x.Name).NotNull().WithMessage("Hesap Planı Adı Boş Geçilemez!");
            RuleFor(x => x.Code).NotNull().WithMessage("Hesap Planı Kodu Boş Geçilemez!");
            RuleFor(x => x.Code).NotEmpty().WithMessage("Hesap Planı Kodu Boş Geçilemez!");
            RuleFor(x => x.Code).MinimumLength(5).WithMessage("Hesap Planı Kodu 5 Karakterden Az Olamaz");
            RuleFor(x => x.Type).MinimumLength(1).WithMessage("Hesap Planı Tipi 1 Karakter Olmalıdır");
        }
    }
}

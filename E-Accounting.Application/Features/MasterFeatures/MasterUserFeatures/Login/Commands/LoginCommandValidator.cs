using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Application.Features.MasterFeatures.MasterUserFeatures.Login.Commands
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(x => x.EmailOrUserName).NotEmpty().WithMessage("Kullanıcı Adı Veya E-Mail Boş Geçilemez");
            RuleFor(x => x.EmailOrUserName).NotNull().WithMessage("Kullanıcı Adı Veya E-Mail Boş Geçilemez");
            RuleFor(p => p.Password).NotEmpty().WithMessage("Şifre Bilgisi Boş Geçilemez");
            RuleFor(p => p.Password).NotNull().WithMessage("Şifre Bilgisi Boş Geçilemez");
            RuleFor(p => p.Password).MinimumLength(6).WithMessage("Şifre Bilgisi Boş Geçilemez...");
            RuleFor(p => p.Password).Matches("[A-Z]").WithMessage("Şifreniz En Az 1 Adet Büyük Harf İçermelidir.");
            RuleFor(p => p.Password).Matches("[a-z]").WithMessage("Şifreniz En Az 1 Adet Küçük Harf İçermelidir.");
            RuleFor(p => p.Password).Matches("[0-9]").WithMessage("Şifreniz En Az 1 Adet Rakam İçermelidir.");
            RuleFor(p => p.Password).Matches("[a-zA-Z0-9]").WithMessage("Şifreniz En Az 1 Adet Özel Karakter İçermelidir.");
        }
    }
}

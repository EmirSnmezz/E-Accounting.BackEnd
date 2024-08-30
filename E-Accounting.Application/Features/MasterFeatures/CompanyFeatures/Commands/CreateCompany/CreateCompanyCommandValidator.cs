using FluentValidation;

namespace E_Accounting.Application.Features.MasterFeatures.CompanyFeatures.Commands.CreateCompany
{
    public sealed class CreateCompanyCommandValidator : AbstractValidator<CreateCompanyCommand> 
    {
        public CreateCompanyCommandValidator()
        {
            RuleFor(x => x.DatabaseName).NotEmpty().WithMessage("Database Bilgisi Boş Geçilemez !");
            RuleFor(x => x.DatabaseName).NotNull().WithMessage("Database Bilgisi Boş Geçilemez !");

            RuleFor(x => x.ServerName).NotEmpty().WithMessage("Server Bilgisi Boş Geçilemez");
            RuleFor(x => x.ServerName).NotNull().WithMessage("Server Bilgisi Boş Geçilemez");

            RuleFor(x => x.Name).NotEmpty().WithMessage("Şirket Adı Bilgisi Boş Geçilemez");
            RuleFor(x => x.Name).NotNull().WithMessage("Şirket Adı Bilgisi Boş Geçilemez");
        }
    }
}

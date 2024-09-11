using FluentValidation;

namespace E_Accounting.Application.Features.MasterFeatures.MainRoleAndUserRelationShipFeatures.Command.Create;
    public sealed class CreateMainRoleAdUserRelationShipCommandValidator : AbstractValidator<CreateMainRoleAndUserRelationShipCommand>
    {
        public CreateMainRoleAdUserRelationShipCommandValidator()
        {
            RuleFor(x => x.userId).NotNull().WithMessage("Kullanıcı Bilgisi Boş Geçilemez");
            RuleFor(x => x.userId).NotEmpty().WithMessage("Kullanıcı Bilgisi Boş Geçilemez");
            RuleFor(x => x.mainRoleId).NotNull().WithMessage("MainRole Bilgisi Boş Geçilememz");
            RuleFor(x => x.mainRoleId).NotEmpty().WithMessage("MainRole Bilgisi Boş Geçilememz");
            RuleFor(x => x.companyId).NotNull().WithMessage("Şirket Bilgisi Boş Geçilemez");
            RuleFor(x => x.companyId).NotEmpty().WithMessage("Şirket Bilgisi Boş Geçilemez");
        }
    }

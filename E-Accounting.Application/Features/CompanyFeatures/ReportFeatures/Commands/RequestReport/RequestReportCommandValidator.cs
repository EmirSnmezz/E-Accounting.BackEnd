using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Application.Features.CompanyFeatures.ReportFeatures.Commands.RequestReport
{
    public sealed class RequestReportCommandValidator : AbstractValidator<RequestReportCommand>
    {
        public RequestReportCommandValidator()
        {
            RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Şirket Bilgisi Boş Olamaz!");
            RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket Bilgisi Boş Olamaz!");
            RuleFor(p => p.Name).NotEmpty().WithMessage("Rapor Adı Bilgisi Boş Olamaz!");
            RuleFor(p => p.Name).NotNull().WithMessage("Rapor Adı Bilgisi Boş Olamaz!");
        }
    }
}

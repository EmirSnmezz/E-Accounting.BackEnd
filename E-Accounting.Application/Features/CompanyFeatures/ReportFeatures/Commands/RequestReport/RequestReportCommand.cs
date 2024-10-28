using E_Accounting.Application.Messaging;

namespace E_Accounting.Application.Features.CompanyFeatures.ReportFeatures.Commands.RequestReport;
public sealed record RequestReportCommand(string Name, string CompanyId) : ICommand<RequestReportCommandResponse>;


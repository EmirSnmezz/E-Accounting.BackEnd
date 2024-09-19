using E_Accounting.Application.Messaging;

namespace E_Accounting.Application.Features.CompanyFeatures.UCAFFeautres.Commands.RemoveUCAF;
public sealed record RemoveUCAFCommand(string id, string companyId) : ICommand<RemoveUCAFCommandResonse>;

using E_Accounting.Application.Messaging;
using System.Windows.Input;

namespace E_Accounting.Application.Features.CompanyFeatures.UCAFFeautres.Commands.UpdateUCAF;
    public sealed record UpdateUCAFCommand(string CompanyId, string Id, string Name, string Code, string Type) : ICommand<UpdateUCAFCommandResponse>;
   

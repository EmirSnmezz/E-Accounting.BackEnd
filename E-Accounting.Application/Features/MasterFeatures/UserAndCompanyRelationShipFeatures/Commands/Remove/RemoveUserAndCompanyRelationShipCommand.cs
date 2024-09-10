using E_Accounting.Application.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace E_Accounting.Application.Features.MasterFeatures.UserAndCompanyRelationShipFeatures.Commands.Remove;
    public sealed record RemoveUserAndCompanyRelationShipCommand(
            string Id
        ) : ICommand<RemoveUserAndCompanyRelationShipCommandResponse>;


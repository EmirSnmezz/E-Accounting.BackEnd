﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Application.Features.CompanyFeatures.Commands.MigrateCompanyDatabase
{
    public sealed class MigrateDatabaseCompanyRequest : IRequest<MigrateDatabaseCompanyResponse>
    {
    }
}

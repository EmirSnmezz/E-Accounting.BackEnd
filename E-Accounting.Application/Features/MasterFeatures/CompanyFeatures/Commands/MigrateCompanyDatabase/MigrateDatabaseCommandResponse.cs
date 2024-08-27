using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Application.Features.MasterFeatures.CompanyFeatures.Commands.MigrateCompanyDatabase
{
    public record MigrateDatabaseCommandResponse
        (
            string Message = "Database Migrate İşlemi Başarıyla Gerçekleşti"
        );
}

using E_Accounting.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Domain.Entities.CompanyEntities
{
    public sealed class Report : BaseEntity
    {
        public string Name { get; set; }
        public bool Status { get; set; }
        public string FileUrl { get; set; }
    }
}

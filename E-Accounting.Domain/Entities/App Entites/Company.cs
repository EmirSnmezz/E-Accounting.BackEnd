using E_Accounting.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Domain.Entities.App_Entites
{
    public sealed class Company : BaseEntiy
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string TaxNumber { get; set; }
        public string TaxDepartment { get; set; }
        public string TelephoneNumber { get; set; }
        public string Email { get; set; }
        public string ServerName { get; set; }
        public string DatabaseName { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }

    }
}

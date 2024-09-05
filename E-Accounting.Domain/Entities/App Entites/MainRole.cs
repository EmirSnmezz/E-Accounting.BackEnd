using E_Accounting.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Domain.Entities.App_Entites
{
    public class MainRole : BaseEntity
    {
        public string Title { get; set; }
        public bool IsRoleCreatedByAdmin { get; set; }
        
        [ForeignKey("Company")]
        public string CompanyId { get; set; }
        public Company? Company { get; set; }
    }
}

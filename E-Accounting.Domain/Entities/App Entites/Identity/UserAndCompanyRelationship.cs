using E_Accounting.Domain.Common;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Domain.Entities.App_Entites.Identity
{
    public sealed class UserAndCompanyRelationship : BaseEntity
    {
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public string CompanyId { get; set; }
        public string Company { get; set; }
    }
}

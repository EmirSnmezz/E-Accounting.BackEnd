using E_Accounting.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace E_Accounting.Domain.Entities.App_Entites
{
    public class UserAndCompanyRelationShip : BaseEntity
    {

        public UserAndCompanyRelationShip()
        {
            
        }


        public UserAndCompanyRelationShip(string Id, string masterUserId, string companyId) : base(Id)
        {
            MasterUserId = masterUserId;
            CompanyId = companyId;
        }

        [ForeignKey("AppUser")]
        public string MasterUserId { get; set; }
        public AppUser MasterUser { get; set; }

        [ForeignKey("Company")]
        public string CompanyId { get; set; }
        public Company Company { get; set; }
    }
}

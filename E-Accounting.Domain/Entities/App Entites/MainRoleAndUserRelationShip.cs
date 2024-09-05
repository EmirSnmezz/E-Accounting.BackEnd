using E_Accounting.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Accounting.Domain.Entities.App_Entites
{
    public sealed class MainRoleAndUserRelationShip : BaseEntity
    {
        [ForeignKey("AppUser")]
        public string UserId { get; set; }
        public AppUser AppUser { get; set; }

        [ForeignKey("MainRole")]
        public string MainRoleId { get; set; }
        public MainRole MainRole { get; set; }

        [ForeignKey("Company")]
        public string CompanyId { get; set; }
        public Company Company { get; set; }
    }
}

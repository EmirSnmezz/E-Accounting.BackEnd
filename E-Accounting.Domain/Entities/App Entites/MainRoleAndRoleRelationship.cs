using E_Accounting.Domain.Common;
using E_Accounting.Domain.Entities.App_Entites.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Accounting.Domain.Entities.App_Entites
{
    public sealed class MainRoleAndRoleRelationship : BaseEntity
    {
        public MainRoleAndRoleRelationship()
        {
            
        }

        public MainRoleAndRoleRelationship(string id, string roleId, string mainRoleId) : base(id)
        {
            RoleId = roleId;
            MainRoleId = mainRoleId;
        }

        [ForeignKey("AppRole")]
        public string RoleId { get; set; }
        public AppRole AppRole { get; set; }
        
        [ForeignKey("MainRole")]
        public string MainRoleId { get; set; }
        public MainRole MainRole { get; set; }
    }
}

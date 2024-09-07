using E_Accounting.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Accounting.Domain.Entities.App_Entites;

public class MainRole : BaseEntity

{
    public MainRole()
    {
        
    }
    public MainRole(string id,string title, bool isRoleCretedByAdmin = false, string companyId = null) : base(id)
    {
        Title = title;
        isRoleCretedByAdmin = IsRoleCreatedByAdmin;
        CompanyId = companyId;
    } 

    public string Title { get; set; }
    public bool IsRoleCreatedByAdmin { get; set; }

    [ForeignKey("Company")]
    public string CompanyId { get; set; }
    public Company? Company { get; set; }
}


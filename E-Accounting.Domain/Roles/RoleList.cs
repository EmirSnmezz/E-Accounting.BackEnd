using E_Accounting.Domain.Entities.App_Entites;
using E_Accounting.Domain.Entities.App_Entites.Identity;

namespace E_Accounting.Domain.Roles
{
    public sealed class RoleList
    {
        public static List<AppRole> GetStaticRoles()
        {
            List<AppRole> roles = new List<AppRole>
            {
            #region RoleTitleNames
           
                new AppRole(UCAFTitle, UCAFCreateCode, UCAFCreateName),
                new AppRole(UCAFTitle, UCAFUpdateCode, UCAFUpdateName),
                new AppRole(UCAFTitle, UCAFDeleteCode, UCAFDeleteName),
                new AppRole(UCAFTitle, UCAFReadCode, UCAFReadName)

            #endregion
            };
            return roles;
        }

        public static List<MainRole> GetStaticMainRoles()
        {
            List<MainRole> mainRoles = new List<MainRole>
            {
                new MainRole(Guid.NewGuid().ToString(), "AdminRole", true),
                new MainRole(Guid.NewGuid().ToString(), "Yönetici", true),
                new MainRole(Guid.NewGuid().ToString(), "Kullanıcı", true),
            };

            return mainRoles;
        }


        #region RoleTitleNames
        public static string UCAFTitle = "Hesap Planı";
        #endregion

        #region RoleCodeAndNames

        public static string UCAFCreateCode = "UCAF.Create";
        public static string UCAFCreateName = "Hesap Planı Kayıt";

        public static string UCAFUpdateCode = "UCAF.Update";
        public static string UCAFUpdateName = "Hesap Planı Güncelleme";

        public static string UCAFDeleteCode = "UCAF.Delete";
        public static string UCAFDeleteName = "Hesap Planı Silme";

        public static string UCAFReadCode = "UCAF.Read";
        public static string UCAFReadName = "Hesap Planı Görüntüleme";

        #endregion
    }
}

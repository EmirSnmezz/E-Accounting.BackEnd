using E_Accounting.Domain.Entities.App_Entites.Identity;

namespace E_Accounting.Domain.Roles
{
    public sealed class RoleList
    {
        public static List<AppRole> GetStaticRoles()
        {
            List<AppRole> roles = new List<AppRole>
            {
            #region
           
                new AppRole(UCAFCreateTitle, UCAFCreateCode, UCAFCreateName),
                new AppRole(UCAFCreateTitle, UCAFUpdateCode, UCAFUpdateName),
                new AppRole(UCAFCreateTitle, UCAFDeleteCode, UCAFDeleteName),
                new AppRole(UCAFCreateTitle, UCAFReadCode, UCAFReadName)

            #endregion
                 };
            return roles;
        }

        #region RoleTitleNames
        public static string UCAFCreateTitle = "Hesap Planı";
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

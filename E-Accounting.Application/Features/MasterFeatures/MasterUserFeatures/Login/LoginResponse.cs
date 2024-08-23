using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Application.Features.MasterFeatures.MasterUserFeatures.Login
{
    public sealed class LoginResponse
    {
        public string Token { get; set; }
        public string Email { get; set; }
        public string UserId { get; set; }
        public string NameAndLastName { get; set; }
        //public string Message { get; set; } = "Kullanıcı Doğrulandı, Giriş Başarılı!";
    }
}

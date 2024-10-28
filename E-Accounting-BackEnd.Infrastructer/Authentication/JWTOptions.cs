

namespace E_Accounting_BackEnd.Infrastructer.Authentication
{
    public sealed class JWTOptions 
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string SecretKey { get; set; }
    }
}

using E_Accounting_BackEnd.Infrastructer.Authentication;
using Microsoft.Extensions.Options;

namespace E_Accounting_BackEnd.API.OptionsSetup
{
    public class JWTOptionsSetup : IConfigureOptions<JWTOptions>
    {
        private const string JWT = nameof(JWT);
        private readonly IConfiguration _configuration;

        public JWTOptionsSetup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void Configure(JWTOptions options)
        {
            _configuration.GetSection(JWT).Bind(options); //appSettings.json'daki JWT'yi options pattern ile JWTOPTİONS classımıza aktarmış bulunduk
        }
    }
}

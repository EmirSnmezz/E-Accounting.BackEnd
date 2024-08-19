using Microsoft.IdentityModel.Protocols;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Persistance.Configuration
{
    public static class MyConfigurationManager
    {
        public static string ConnectionString
        {
            get
            {
                ConfigurationManager config = new();
                config.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/E-Accounting-BackEnd.API"));
                config.AddJsonFile("appsettings.json");
                return config.GetConnectionString("SQLServer");
            }      

        }

    }
}
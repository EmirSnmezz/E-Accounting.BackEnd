using E_Accounting.Persistance.Configuration;
using E_Accounting.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Persistance.Registrations
{
    public  static class ServiceRegistration
    {
         public static void AddDbContext(this IServiceCollection service)
        {
            service.AddDbContext<MasterDbContext>(options =>
            options.UseSqlServer("Data Source=EMIRSNMEZ;Initial Catalog=E-Accounting-Master;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False"));
        }
    }
}

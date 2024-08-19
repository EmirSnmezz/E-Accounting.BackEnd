using E_Accounting.Persistance.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Persistance.Contexts.DesignTimeFactories
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MasterDbContext>
    {
        public MasterDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<MasterDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseSqlServer("Data Source=EMIRSNMEZ;Initial Catalog=E-Accounting-Master;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
            return new(dbContextOptionsBuilder.Options);
        }
    }
}

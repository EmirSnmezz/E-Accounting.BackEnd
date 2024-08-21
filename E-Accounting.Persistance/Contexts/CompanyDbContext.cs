using E_Accounting.Domain.Entities.App_Entites;
using E_Accounting.Persistance.AssemblyReferance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.Persistance.Contexts
{
    public class CompanyDbContext : DbContext
    {
        protected string _connectionString = "";
        public CompanyDbContext(string companyId, Company company = null)
        {
            if(company != null)
            {
                if (company.UserId == "")
                {
                    _connectionString =
                    $"Data Source={company.ServerName};" +
                    $"Initial Catalog={company.DatabaseName};" +
                    $"Integrated Security=True;" +
                    $"Connect Timeout=30;" +
                    $"Encrypt=True;" +
                    $"Trust Server Certificate=True;" +
                    $"Application Intent=ReadWrite;" +
                    $"Multi Subnet Failover=False";
                }
                else
                {
                    _connectionString =
                   $"Data Source={company.ServerName};" +
                   $"Initial Catalog={company.DatabaseName};" +
                   $"User Id={company.UserId}" +
                   $"Password={company.Password}" +
                   $"Integrated Security=True;" +
                   $"Connect Timeout=30;" +
                   $"Encrypt=True;" +
                   $"Trust Server Certificate=True;" +
                   $"Application Intent=ReadWrite;" +
                   $"Multi Subnet Failover=False";
                }
            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyManager).Assembly); // bu kod sayesinde DbSet'leri tek tek elimizle girmek zorunda kalmıyoruz
        }

        public class CompanyDbContextFactory : IDesignTimeDbContextFactory<CompanyDbContext>
        {
            public CompanyDbContext CreateDbContext(string[] args)
            {   
                return new CompanyDbContext("");
            }
        }
    }
}

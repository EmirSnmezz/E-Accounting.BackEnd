using E_Accounting.Domain.Entities.CompanyEntities;
using E_Accounting.Persistance.Constans;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Accounting.Persistance.Configuration
{
    public sealed class UCAFConfig : IEntityTypeConfiguration<UniformChartOfAccount> // IEntityTypeConfiguration<T>, T için veritabanı yapılandırmasını sağlamak üzere kullanılır
    {
        public void Configure(EntityTypeBuilder<UniformChartOfAccount> builder)
        {
            builder.ToTable(TableNames.UniFormChartAccounts);
            builder.HasKey(p => p.Id);
        }
    }
}

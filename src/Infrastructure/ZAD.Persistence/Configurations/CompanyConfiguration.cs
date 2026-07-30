using ZAD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ZAD.Persistence.Configurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Code)
            .IsUnique();
            builder.Property(x => x.Code).IsRequired().HasMaxLength(50);
            builder.Property(x => x.NameAr).IsRequired().HasMaxLength(200);
            builder.Property(x => x.NameEn).IsRequired().HasMaxLength(200);
            
        }
    }
}

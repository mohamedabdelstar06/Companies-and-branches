using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZAD.Domain.Entities.Lookups;

namespace ZAD.Persistence.Configurations
{
    public class LookupConfiguration : IEntityTypeConfiguration<Lookup>
    {
        public void Configure(EntityTypeBuilder<Lookup> builder)
        {
            builder.HasKey(x => x.Id);
            
            builder.Property(x => x.LookupKey).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Culture).IsRequired().HasMaxLength(10);
            builder.Property(x => x.Value).IsRequired().HasMaxLength(500);

            builder.HasIndex(x => new { x.LookupKey, x.Culture }).IsUnique();
        }
    }
}

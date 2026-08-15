using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZAD.Domain.Entities.Branches;

namespace ZAD.Persistence.Configurations
{
    public class BranchConfiguration : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Code).IsUnique();
            
            builder.Property(x => x.Code).IsRequired().HasMaxLength(50);
            builder.Property(x => x.NameAr).IsRequired().HasMaxLength(200);
            builder.Property(x => x.NameEn).IsRequired().HasMaxLength(200);

            builder.HasOne(b => b.Company)
                   .WithMany()
                   .HasForeignKey(b => b.CompanyId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.OwnsOne(x => x.Address, a =>
            {
                a.Property(p => p.Country).HasColumnName("Country").HasMaxLength(100);
                a.Property(p => p.City).HasColumnName("City").HasMaxLength(100);
                a.Property(p => p.AddressAr).HasColumnName("AddressAr").HasMaxLength(500);
                a.Property(p => p.AddressEn).HasColumnName("AddressEn").HasMaxLength(500);
            });


            builder.OwnsMany(x => x.Contacts, c =>
            {
                c.ToTable("BranchContacts");
                c.WithOwner().HasForeignKey("BranchId");
                c.HasKey(x => x.Id);
                c.Property(x => x.Type).IsRequired();
                c.Property(x => x.Value).IsRequired().HasMaxLength(255);
                c.Property(x => x.Name).HasMaxLength(255);
            });

            builder.OwnsMany(x => x.Documents, d =>
            {
                d.ToTable("BranchDocuments");
                d.WithOwner().HasForeignKey("BranchId");
                d.HasKey(x => x.Id);
                d.Property(x => x.Type).IsRequired();
                d.Property(x => x.DocumentNumber).IsRequired().HasMaxLength(100);
                d.Property(x => x.FilePath).IsRequired().HasMaxLength(500);
            });
        }
    }
}

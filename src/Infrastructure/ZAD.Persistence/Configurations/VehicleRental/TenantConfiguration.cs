using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZAD.Domain.Entities.VehicleRental.Tenants;

namespace ZAD.Persistence.Configurations.VehicleRental
{
    public class TenantConfiguration : IEntityTypeConfiguration<Tenant>
    {
        public void Configure(EntityTypeBuilder<Tenant> builder)
        {
            builder.ToTable("Tenants");
            builder.HasKey(x => x.Id);
            
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            builder.Property(x => x.LicenseNumber).HasMaxLength(50);
            builder.Property(x => x.PassportNumber).HasMaxLength(50);
            builder.Property(x => x.UnifiedNumber).HasMaxLength(50);
            builder.Property(x => x.IdNumber).HasMaxLength(50);
            builder.Property(x => x.Mobile).HasMaxLength(20);

            // Seed dummy data
            var now = new System.DateTime(2026, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);
            builder.HasData(
                new { Id = 1, Name = "أحمد محمود", LicenseNumber = "L1001", PassportNumber = "P1001", UnifiedNumber = "U1001", IdNumber = "I1001", Mobile = "01000000001", Birthday = new System.DateTime(1990, 1, 1), IsDeleted = false, CreatedAt = now },
                new { Id = 2, Name = "محمد علي", LicenseNumber = "L1002", PassportNumber = "P1002", UnifiedNumber = "U1002", IdNumber = "I1002", Mobile = "01000000002", Birthday = new System.DateTime(1985, 5, 15), IsDeleted = false, CreatedAt = now },
                new { Id = 3, Name = "محمود حسن", LicenseNumber = "L1003", PassportNumber = "P1003", UnifiedNumber = "U1003", IdNumber = "I1003", Mobile = "01000000003", Birthday = new System.DateTime(1992, 8, 20), IsDeleted = false, CreatedAt = now },
                new { Id = 4, Name = "عمر فاروق", LicenseNumber = "L1004", PassportNumber = "P1004", UnifiedNumber = "U1004", IdNumber = "I1004", Mobile = "01000000004", Birthday = new System.DateTime(1988, 3, 10), IsDeleted = false, CreatedAt = now },
                new { Id = 5, Name = "عبد الله إبراهيم", LicenseNumber = "L1005", PassportNumber = "P1005", UnifiedNumber = "U1005", IdNumber = "I1005", Mobile = "01000000005", Birthday = new System.DateTime(1995, 11, 25), IsDeleted = false, CreatedAt = now },
                new { Id = 6, Name = "يوسف مصطفى", LicenseNumber = "L1006", PassportNumber = "P1006", UnifiedNumber = "U1006", IdNumber = "I1006", Mobile = "01000000006", Birthday = new System.DateTime(1980, 7, 30), IsDeleted = false, CreatedAt = now },
                new { Id = 7, Name = "حسين عبد الرحمن", LicenseNumber = "L1007", PassportNumber = "P1007", UnifiedNumber = "U1007", IdNumber = "I1007", Mobile = "01000000007", Birthday = new System.DateTime(1975, 12, 5), IsDeleted = false, CreatedAt = now },
                new { Id = 8, Name = "سعيد سليمان", LicenseNumber = "L1008", PassportNumber = "P1008", UnifiedNumber = "U1008", IdNumber = "I1008", Mobile = "01000000008", Birthday = new System.DateTime(1999, 9, 18), IsDeleted = false, CreatedAt = now },
                new { Id = 9, Name = "طارق يحيى", LicenseNumber = "L1009", PassportNumber = "P1009", UnifiedNumber = "U1009", IdNumber = "I1009", Mobile = "01000000009", Birthday = new System.DateTime(1971, 4, 12), IsDeleted = false, CreatedAt = now },
                new { Id = 10, Name = "حسن حمدي", LicenseNumber = "L1010", PassportNumber = "P1010", UnifiedNumber = "U1010", IdNumber = "I1010", Mobile = "01000000010", Birthday = new System.DateTime(1982, 11, 30), IsDeleted = false, CreatedAt = now },
                new { Id = 11, Name = "خالد زكي", LicenseNumber = "L1011", PassportNumber = "P1011", UnifiedNumber = "U1011", IdNumber = "I1011", Mobile = "01000000011", Birthday = new System.DateTime(1993, 2, 14), IsDeleted = false, CreatedAt = now },
                new { Id = 12, Name = "ماجد الكدواني", LicenseNumber = "L1012", PassportNumber = "P1012", UnifiedNumber = "U1012", IdNumber = "I1012", Mobile = "01000000012", Birthday = new System.DateTime(1978, 8, 8), IsDeleted = false, CreatedAt = now },
                new { Id = 13, Name = "أمير كرارة", LicenseNumber = "L1013", PassportNumber = "P1013", UnifiedNumber = "U1013", IdNumber = "I1013", Mobile = "01000000013", Birthday = new System.DateTime(1989, 5, 21), IsDeleted = false, CreatedAt = now },
                new { Id = 14, Name = "صالح جمعة", LicenseNumber = "L1014", PassportNumber = "P1014", UnifiedNumber = "U1014", IdNumber = "I1014", Mobile = "01000000014", Birthday = new System.DateTime(1996, 1, 19), IsDeleted = false, CreatedAt = now },
                new { Id = 15, Name = "عبد الله جمعة", LicenseNumber = "L1015", PassportNumber = "P1015", UnifiedNumber = "U1015", IdNumber = "I1015", Mobile = "01000000015", Birthday = new System.DateTime(1997, 7, 7), IsDeleted = false, CreatedAt = now },
                new { Id = 16, Name = "باسم مرسي", LicenseNumber = "L1016", PassportNumber = "P1016", UnifiedNumber = "U1016", IdNumber = "I1016", Mobile = "01000000016", Birthday = new System.DateTime(1991, 10, 10), IsDeleted = false, CreatedAt = now },
                new { Id = 17, Name = "حازم إمام", LicenseNumber = "L1017", PassportNumber = "P1017", UnifiedNumber = "U1017", IdNumber = "I1017", Mobile = "01000000017", Birthday = new System.DateTime(1979, 3, 3), IsDeleted = false, CreatedAt = now },
                new { Id = 18, Name = "عصام الحضري", LicenseNumber = "L1018", PassportNumber = "P1018", UnifiedNumber = "U1018", IdNumber = "I1018", Mobile = "01000000018", Birthday = new System.DateTime(1973, 1, 15), IsDeleted = false, CreatedAt = now },
                new { Id = 19, Name = "وائل جمعة", LicenseNumber = "L1019", PassportNumber = "P1019", UnifiedNumber = "U1019", IdNumber = "I1019", Mobile = "01000000019", Birthday = new System.DateTime(1976, 8, 3), IsDeleted = false, CreatedAt = now },
                new { Id = 20, Name = "محمد أبو تريكة", LicenseNumber = "L1020", PassportNumber = "P1020", UnifiedNumber = "U1020", IdNumber = "I1020", Mobile = "01000000020", Birthday = new System.DateTime(1978, 11, 7), IsDeleted = false, CreatedAt = now },
                new { Id = 21, Name = "أحمد حسن", LicenseNumber = "L1021", PassportNumber = "P1021", UnifiedNumber = "U1021", IdNumber = "I1021", Mobile = "01000000021", Birthday = new System.DateTime(1975, 5, 2), IsDeleted = false, CreatedAt = now },
                new { Id = 22, Name = "محمد صلاح", LicenseNumber = "L1022", PassportNumber = "P1022", UnifiedNumber = "U1022", IdNumber = "I1022", Mobile = "01000000022", Birthday = new System.DateTime(1992, 6, 15), IsDeleted = false, CreatedAt = now },
                new { Id = 23, Name = "محمود تريزيجيه", LicenseNumber = "L1023", PassportNumber = "P1023", UnifiedNumber = "U1023", IdNumber = "I1023", Mobile = "01000000023", Birthday = new System.DateTime(1994, 10, 1), IsDeleted = false, CreatedAt = now },
                new { Id = 24, Name = "عمر مرموش", LicenseNumber = "L1024", PassportNumber = "P1024", UnifiedNumber = "U1024", IdNumber = "I1024", Mobile = "01000000024", Birthday = new System.DateTime(1999, 2, 7), IsDeleted = false, CreatedAt = now },
                new { Id = 25, Name = "مصطفى محمد", LicenseNumber = "L1025", PassportNumber = "P1025", UnifiedNumber = "U1025", IdNumber = "I1025", Mobile = "01000000025", Birthday = new System.DateTime(1997, 11, 28), IsDeleted = false, CreatedAt = now }
            );
        }
    }
}

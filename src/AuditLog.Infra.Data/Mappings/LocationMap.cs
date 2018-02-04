using AuditLog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuditLog.Infra.Data.Mappings
{
    public class LocationMap : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.ToTable("TB_LOCATIONS");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();
            builder.Property(x => x.RequestId).IsRequired();
            builder.Property(x => x.UserAgent).HasMaxLength(150).IsRequired();
            builder.Property(x => x.IP).HasMaxLength(15);
            builder.Property(x => x.CountryCode).HasMaxLength(3);
            builder.Property(x => x.CountryName).HasMaxLength(50);
            builder.Property(x => x.RegionCode).HasMaxLength(4);
            builder.Property(x => x.RegionName).HasMaxLength(80);
            builder.Property(x => x.TimeZone).HasMaxLength(50);
            builder.Property(x => x.Longitude).HasColumnType("decimal(11, 8)");
            builder.Property(x => x.Latitude).HasColumnType("decimal(10, 8)");

            #region IGNORE
            builder.Ignore(x => x.ValidationResult);
            builder.Ignore(x => x.CascadeMode);
            #endregion
        }
    }
}

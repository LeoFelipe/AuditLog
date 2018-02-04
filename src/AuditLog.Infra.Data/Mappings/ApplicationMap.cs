using AuditLog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuditLog.Infra.Data.Mappings
{
    public class ApplicationMap : IEntityTypeConfiguration<Application>
    {
        public void Configure(EntityTypeBuilder<Application> builder)
        {
            builder.ToTable("TB_APPLICATIONS");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Active).IsRequired();

            #region IGNORE
            builder.Ignore(x => x.ValidationResult);
            builder.Ignore(x => x.CascadeMode);
            #endregion
        }
    }
}

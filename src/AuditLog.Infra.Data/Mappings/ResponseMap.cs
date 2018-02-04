using AuditLog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuditLog.Infra.Data.Mappings
{
    public class ResponseMap : IEntityTypeConfiguration<Response>
    {
        public void Configure(EntityTypeBuilder<Response> builder)
        {
            builder.ToTable("TB_RESPONSES");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();
            builder.Property(x => x.RequestId).IsRequired();
            builder.Property(x => x.JsonResponseClient).IsRequired();
            builder.Property(x => x.JsonResponseOriginal).IsRequired();
            builder.Property(x => x.HttpCode).IsRequired();
            builder.Property(x => x.HttpHeader).IsRequired();
            builder.Property(x => x.HttpDescription).HasMaxLength(30).IsRequired();
            builder.Property(x => x.FlagError).IsRequired();

            #region IGNORE
            builder.Ignore(x => x.ValidationResult);
            builder.Ignore(x => x.CascadeMode);
            #endregion
        }
    }
}

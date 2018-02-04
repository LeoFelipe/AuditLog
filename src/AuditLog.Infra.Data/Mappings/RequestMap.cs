using AuditLog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuditLog.Infra.Data.Mappings
{
    public class RequestMap : IEntityTypeConfiguration<Request>
    {
        public void Configure(EntityTypeBuilder<Request> builder)
        {
            builder.ToTable("TB_REQUESTS");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.ApplicationId).IsRequired();
            builder.Property(x => x.HttpMethod).HasMaxLength(10).IsRequired();
            builder.Property(x => x.HttpHeader).IsRequired();
            builder.Property(x => x.Uri).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Controller).HasMaxLength(30).IsRequired();
            builder.Property(x => x.Action).HasMaxLength(50).IsRequired();
            builder.Property(x => x.DataBase).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Table).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Json);
            builder.Property(x => x.Date).IsRequired();

            builder.HasOne(x => x.Application)
                .WithMany(y => y.Requests)
                .HasForeignKey(x => x.ApplicationId);

            builder.HasOne(x => x.Response)
                .WithOne(y => y.Request)
                .HasForeignKey<Response>(x => x.RequestId);

            builder.HasOne(x => x.Location)
                .WithOne(y => y.Request)
                .HasForeignKey<Location>(x => x.RequestId);

            #region IGNORE
            builder.Ignore(x => x.ValidationResult);
            builder.Ignore(x => x.CascadeMode);
            #endregion
        }
    }
}
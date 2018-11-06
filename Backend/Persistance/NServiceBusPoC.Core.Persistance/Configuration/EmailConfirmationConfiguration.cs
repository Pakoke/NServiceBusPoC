using NServiceBusPoC.Core.Persistance.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NServiceBusPoC.Core.Persistance.Configuration
{
    public class EmailConfirmationConfiguration : IEntityTypeConfiguration<EmailConfirmation>
    {
        public void Configure(EntityTypeBuilder<EmailConfirmation> builder)
        {
            builder.ToTable("EmailConfirmations");
            builder.HasKey(e => new { e.Email, e.RoleId, e.GuidUrl });
            builder.Property(e => e.Email).IsRequired();
            builder.Property(e => e.RoleId).IsRequired();
            builder.Property(e => e.CreatedDate).IsRequired().HasDefaultValueSql("GetDate()");
            builder.Property(e => e.ExpirationDate).IsRequired();
            builder.Property(e => e.GuidUrl).IsRequired();
            builder.Property(e => e.Consumed).IsRequired().HasDefaultValueSql<bool>("0");

        }
    }
}

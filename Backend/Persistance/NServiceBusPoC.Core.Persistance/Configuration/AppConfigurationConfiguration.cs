using NServiceBusPoC.Core.Persistance.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NServiceBusPoC.Core.Persistance.Configuration
{
    public class AppConfigurationConfiguration : IEntityTypeConfiguration<AppConfiguration>
    {
        public void Configure(EntityTypeBuilder<AppConfiguration> builder)
        {
            builder.ToTable("AppConfiguration");
            builder.HasKey(c => c.ConfigurationId);
            builder.Property(c => c.ConfigurationId).ValueGeneratedOnAdd().IsRequired();
            builder.Property(c => c.Name).IsRequired().HasMaxLength(45);
            builder.Property(c => c.Value).IsRequired().HasMaxLength(1000);
            builder.Property(c => c.Description).IsRequired().HasMaxLength(200);

        }
    }
}

using NServiceBusPoC.Core.Persistance.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NServiceBusPoC.Core.Persistance.Configuration
{
    public class ClubConfiguration : IEntityTypeConfiguration<Club>
    {
        public void Configure(EntityTypeBuilder<Club> builder)
        {
            builder.ToTable("Clubs");
            builder.HasKey(c => c.ClubId);
            builder.Property(c => c.ClubId).ValueGeneratedOnAdd().IsRequired();
            builder.Property(c => c.ClubName).IsRequired().HasMaxLength(45);
            builder.Property(c => c.Location).IsRequired().HasMaxLength(200);
            builder.Property(c => c.LimitDateChild).IsRequired().HasDefaultValue(5);
            builder.Property(c => c.Contact).HasMaxLength(15);
            builder.Property(c => c.NumberOfCoach).IsRequired().HasDefaultValue(0);

        }
    }
}

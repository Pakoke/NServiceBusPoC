using NServiceBusPoC.Core.Persistance.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NServiceBusPoC.Core.Persistance.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(u => new { u.Email, u.RoleId });
            builder.Property(u => u.UserId).ValueGeneratedOnAdd().IsRequired();
            builder.Property(u => u.Email).IsRequired().HasMaxLength(50);
            builder.Property(u => u.Enabled).IsRequired();//False value on mysql
            builder.Property(u => u.Name).HasMaxLength(30);
            builder.Property(u => u.Surname).HasMaxLength(50);
            builder.Property(u => u.SecondSurname).HasMaxLength(50);
            builder.Property(u => u.SecondName).HasMaxLength(50);
            builder.Property(u => u.Password).HasMaxLength(30).IsRequired();
            builder.Property(u => u.Country).IsRequired();
            builder.Property(u => u.RoleId).IsRequired();
            builder.Property(u => u.Nationality).IsRequired();
            builder.Property(u => u.Street).IsRequired();
            builder.Property(u => u.DNI).IsRequired();
            builder.Property(u => u.Country).IsRequired();
            builder.Property(u => u.BirthDate).IsRequired();

        }
    }
}

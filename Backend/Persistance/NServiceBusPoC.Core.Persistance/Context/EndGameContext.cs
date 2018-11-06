using NServiceBusPoC.Core.Persistance.Configuration;
using NServiceBusPoC.Core.Persistance.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;

namespace NServiceBusPoC.Core.Persistance.Context
{
    public class NServiceBusPoCContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Club> Clubs { get; set; }

        public NServiceBusPoCContext(DbContextOptions<NServiceBusPoCContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ClubConfiguration());
            modelBuilder.ApplyConfiguration(new EmailConfirmationConfiguration());
            modelBuilder.ApplyConfiguration(new AppConfigurationConfiguration());
        }

        public EntityEntry<TEntity> GetEntry<TEntity>(TEntity entity) where TEntity : class
        {
            return Entry(entity);
        }

        public DbSet<TEntity> GetSet<TEntity>() where TEntity : class
        {
            return Set<TEntity>();
        }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (Exception e)
            {

                throw new ApplicationException("DbEntityValidationException thrown during SaveChanges: " + e.Message, e);
            }
        }

    }
}

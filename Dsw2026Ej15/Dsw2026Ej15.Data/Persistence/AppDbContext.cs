using Dsw2026Ej15.Domain.Entitys;
using Microsoft.EntityFrameworkCore;

namespace Dsw2026Ej15.Data.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Speciality> Specialities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Speciality>(entity =>
            {
                entity.HasKey(s => s.Id);
                entity.Property(s => s.Name).IsRequired().HasMaxLength(100);
                entity.Property(s => s.Description).HasMaxLength(300);
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(d => d.Id);
                entity.Property(d => d.Name).IsRequired().HasMaxLength(150);
                entity.Property(d => d.LicenseNumber).IsRequired().HasMaxLength(50);
                entity.Property(d => d.IsActive).IsRequired();

                entity.HasOne(d => d.Speciality)
                      .WithMany()
                      .IsRequired();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}

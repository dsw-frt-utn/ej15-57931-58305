using Dsw2026Ej15.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Dsw2026Ej15.Data.Entities
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

                entity.HasKey(s => s._id);

                entity.Property(s => s._name).IsRequired().HasMaxLength(100);

                entity.Property(s => s._description).HasMaxLength(300);

            });


            modelBuilder.Entity<Doctor>(entity =>
            {

                entity.HasKey(d => d._id);

                entity.Property(d => d._name).IsRequired().HasMaxLength(150);

                entity.Property(d => d._licenseNumber).IsRequired().HasMaxLength(50);

                entity.Property(d => d._isActive).IsRequired();


                entity.HasOne(d => d._speciality)

                      .WithMany()

                      .HasForeignKey("SpecialityId")

                      .IsRequired();

            });


            base.OnModelCreating(modelBuilder);

        }
    }
}

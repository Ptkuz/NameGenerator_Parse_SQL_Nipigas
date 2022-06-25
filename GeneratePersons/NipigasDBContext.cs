using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GeneratePersons
{
    public partial class NipigasDBContext : DbContext
    {
        public NipigasDBContext()
        {
        }

        public NipigasDBContext(DbContextOptions<NipigasDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<FakeIdentity> NameGenerators { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=GURREX\\SQLEXPRESS;Database=NipigasDB;MultipleActiveResultSets=True;Trusted_Connection=True;TrustServerCertificate=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FakeIdentity>(entity =>
            {
                entity.ToTable("NameGenerator");

                entity.Property(e => e.Addres).HasMaxLength(300);

                entity.Property(e => e.BloodType)
                    .HasMaxLength(256)
                    .HasColumnName("Blood_Type");

                entity.Property(e => e.Company).HasMaxLength(256);

                entity.Property(e => e.CountryCode).HasColumnName("Country_Code");

                entity.Property(e => e.Cvc2).HasColumnName("CVC2");

                entity.Property(e => e.Email).HasMaxLength(300);

                entity.Property(e => e.Expires).HasMaxLength(256);

                entity.Property(e => e.FavoriteColor)
                    .HasMaxLength(256)
                    .HasColumnName("Favorite_Color");

                entity.Property(e => e.GeoCoordinates)
                    .HasMaxLength(256)
                    .HasColumnName("Geo_Coordinates");

                entity.Property(e => e.Guid)
                    .HasMaxLength(500)
                    .HasColumnName("GUID");

                entity.Property(e => e.Height).HasMaxLength(256);

                entity.Property(e => e.MasterCard).HasMaxLength(256);

                entity.Property(e => e.MothersMaidenName)
                    .HasMaxLength(256)
                    .HasColumnName("Mothers_Maiden_Name");

                entity.Property(e => e.Occupation).HasMaxLength(300);

                entity.Property(e => e.Password).HasMaxLength(256);

                entity.Property(e => e.PersonName)
                    .HasMaxLength(256)
                    .HasColumnName("Person_Name");

                entity.Property(e => e.Phone).HasMaxLength(256);

                entity.Property(e => e.Ssn)
                    .HasMaxLength(256)
                    .HasColumnName("SSN");

                entity.Property(e => e.TropicalZodiac)
                    .HasMaxLength(256)
                    .HasColumnName("Tropical_Zodiac");

                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.Property(e => e.Website).HasMaxLength(256);

                entity.Property(e => e.Weight).HasMaxLength(256);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

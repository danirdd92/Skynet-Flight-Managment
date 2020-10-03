using Microsoft.EntityFrameworkCore;
using Skynet.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skynet.Entities
{
    public class SkynetContext : DbContext
    {


        public SkynetContext(DbContextOptions<SkynetContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Airline> Airlines { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Flight> Flights { get; set; }
        public virtual DbSet<UserFlights> UserFlights { get; set; }
        public virtual DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Airline>(entity =>
            {
                entity.HasKey(e => e.AirlineId)
                    .HasName("PK__Airlines__DC4582136FF68F6F");

                entity.Property(e => e.AirlineId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Abbreviation)
                    .IsRequired()
                    .HasMaxLength(16);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Airline)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK__Airlines__Countr__398D8EEE");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.CountryId)
                    .HasName("PK__Countrie__10D1609F889C5CE3");

                entity.HasIndex(e => new { e.CountryId, e.Name })
                    .HasName("IX_Countries")
                    .IsUnique();

                entity.Property(e => e.CountryId).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(64);
            });

            modelBuilder.Entity<Flight>(entity =>
            {
                entity.HasKey(e => e.FlightId)
                    .HasName("PK__Flights__8A9E14EE3F8B4862");

                entity.HasIndex(e => new { e.FlightId, e.AirlineId })
                    .HasName("IX_Flights")
                    .IsUnique();

                entity.Property(e => e.FlightId).ValueGeneratedNever();

                entity.HasOne(d => d.Airline)
                    .WithMany(p => p.Flights)
                    .HasForeignKey(d => d.AirlineId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Flights__Airline__3C69FB99");

                entity.HasOne(d => d.DestinationCountry)
                    .WithMany(p => p.FlightsDestinationCountry)
                    .HasForeignKey(d => d.DestinationCountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Flights__Destina__3E52440B");

                entity.HasOne(d => d.OriginCountry)
                    .WithMany(p => p.FlightsOriginCountry)
                    .HasForeignKey(d => d.OriginCountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Flights__OriginC__3D5E1FD2");
            });

            modelBuilder.Entity<UserFlights>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.FlightId });

                entity.HasOne(d => d.Flight)
                    .WithMany(p => p.UserFlights)
                    .HasForeignKey(d => d.FlightId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Flights");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserFlights)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Users__1788CC4C7EA6D238");

                entity.HasIndex(e => new { e.UserId, e.FirstName, e.LastName })
                    .HasName("IX_Users")
                    .IsUnique();

                entity.Property(e => e.UserId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(32);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(32);
            });

        }

    }
}


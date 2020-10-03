﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Skynet.Entities;

namespace Skynet.Api.Migrations
{
    [DbContext(typeof(SkynetContext))]
    [Migration("20201003221104_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Skynet.Entities.Models.Airline", b =>
                {
                    b.Property<Guid>("AirlineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("Abbreviation")
                        .IsRequired()
                        .HasColumnType("nvarchar(16)")
                        .HasMaxLength(16);

                    b.Property<int?>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.HasKey("AirlineId")
                        .HasName("PK__Airlines__DC4582136FF68F6F");

                    b.HasIndex("CountryId");

                    b.ToTable("Airlines");

                    b.HasData(
                        new
                        {
                            AirlineId = new Guid("a54e4ceb-9005-4768-978f-22f0c010829b"),
                            Abbreviation = "ELAL",
                            CountryId = 1,
                            Name = "El Al"
                        },
                        new
                        {
                            AirlineId = new Guid("831251dc-06f3-4557-a6bb-edbe7371c253"),
                            Abbreviation = "DAL",
                            CountryId = 2,
                            Name = "Delta Air Lines"
                        },
                        new
                        {
                            AirlineId = new Guid("a308f4d3-656a-43ab-bd44-075934278426"),
                            Abbreviation = "AAL",
                            CountryId = 2,
                            Name = "American Airlines"
                        },
                        new
                        {
                            AirlineId = new Guid("cac3d5f7-43d8-4d71-9041-c2cae939d311"),
                            Abbreviation = "BRA",
                            CountryId = 3,
                            Name = "British Airways"
                        },
                        new
                        {
                            AirlineId = new Guid("3c8ae801-6e2e-42d9-9254-277b284d72c5"),
                            Abbreviation = "VRA",
                            CountryId = 3,
                            Name = "Virgin Atlantic"
                        },
                        new
                        {
                            AirlineId = new Guid("6739c7b3-b0f4-42ac-a8c8-7732cb4983e8"),
                            Abbreviation = "JAL",
                            CountryId = 4,
                            Name = "Japan Airlines"
                        },
                        new
                        {
                            AirlineId = new Guid("75c8b747-e2de-4aa7-a6d4-f19e6816244b"),
                            Abbreviation = "ANA",
                            CountryId = 4,
                            Name = "All Nippon Airways"
                        });
                });

            modelBuilder.Entity("Skynet.Entities.Models.Country", b =>
                {
                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.HasKey("CountryId")
                        .HasName("PK__Countrie__10D1609F889C5CE3");

                    b.HasIndex("CountryId", "Name")
                        .IsUnique()
                        .HasName("IX_Countries");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            CountryId = 1,
                            Name = "Israel"
                        },
                        new
                        {
                            CountryId = 2,
                            Name = "USA"
                        },
                        new
                        {
                            CountryId = 3,
                            Name = "UK"
                        },
                        new
                        {
                            CountryId = 4,
                            Name = "Japan"
                        });
                });

            modelBuilder.Entity("Skynet.Entities.Models.Flight", b =>
                {
                    b.Property<int>("FlightId")
                        .HasColumnType("int");

                    b.Property<Guid>("AirlineId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Arrival")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Departure")
                        .HasColumnType("datetime2");

                    b.Property<int>("DestinationCountryId")
                        .HasColumnType("int");

                    b.Property<int>("OriginCountryId")
                        .HasColumnType("int");

                    b.HasKey("FlightId")
                        .HasName("PK__Flights__8A9E14EE3F8B4862");

                    b.HasIndex("AirlineId");

                    b.HasIndex("DestinationCountryId");

                    b.HasIndex("OriginCountryId");

                    b.HasIndex("FlightId", "AirlineId")
                        .IsUnique()
                        .HasName("IX_Flights");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("Skynet.Entities.Models.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(32)")
                        .HasMaxLength(32);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(32)")
                        .HasMaxLength(32);

                    b.HasKey("UserId")
                        .HasName("PK__Users__1788CC4C7EA6D238");

                    b.HasIndex("UserId", "FirstName", "LastName")
                        .IsUnique()
                        .HasName("IX_Users");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Skynet.Entities.Models.UserFlights", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("FlightId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "FlightId");

                    b.HasIndex("FlightId");

                    b.ToTable("UserFlights");
                });

            modelBuilder.Entity("Skynet.Entities.Models.Airline", b =>
                {
                    b.HasOne("Skynet.Entities.Models.Country", "Country")
                        .WithMany("Airline")
                        .HasForeignKey("CountryId")
                        .HasConstraintName("FK__Airlines__Countr__398D8EEE");
                });

            modelBuilder.Entity("Skynet.Entities.Models.Flight", b =>
                {
                    b.HasOne("Skynet.Entities.Models.Airline", "Airline")
                        .WithMany("Flights")
                        .HasForeignKey("AirlineId")
                        .HasConstraintName("FK__Flights__Airline__3C69FB99")
                        .IsRequired();

                    b.HasOne("Skynet.Entities.Models.Country", "DestinationCountry")
                        .WithMany("FlightsDestinationCountry")
                        .HasForeignKey("DestinationCountryId")
                        .HasConstraintName("FK__Flights__Destina__3E52440B")
                        .IsRequired();

                    b.HasOne("Skynet.Entities.Models.Country", "OriginCountry")
                        .WithMany("FlightsOriginCountry")
                        .HasForeignKey("OriginCountryId")
                        .HasConstraintName("FK__Flights__OriginC__3D5E1FD2")
                        .IsRequired();
                });

            modelBuilder.Entity("Skynet.Entities.Models.UserFlights", b =>
                {
                    b.HasOne("Skynet.Entities.Models.Flight", "Flight")
                        .WithMany("UserFlights")
                        .HasForeignKey("FlightId")
                        .HasConstraintName("FK_Flights")
                        .IsRequired();

                    b.HasOne("Skynet.Entities.Models.User", "User")
                        .WithMany("UserFlights")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Users")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
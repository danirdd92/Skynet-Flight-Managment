using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skynet.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skynet.Entities.SeedingConfigurations
{
    public class AirlineConfiguration : IEntityTypeConfiguration<Airline>

    {
        public void Configure(EntityTypeBuilder<Airline> builder)
        {
            builder.HasData(
                new Airline
                {
                    AirlineId = new Guid("a54e4ceb-9005-4768-978f-22f0c010829b"),
                    Name = "El Al",
                    Abbreviation = "ELAL",
                    CountryId = 1
                }, new Airline
                {
                    AirlineId = new Guid("831251dc-06f3-4557-a6bb-edbe7371c253"),
                    Name = "Delta Air Lines",
                    Abbreviation = "DAL",
                    CountryId = 2
                }, new Airline
                {
                    AirlineId = new Guid("a308f4d3-656a-43ab-bd44-075934278426"),
                    Name = "American Airlines",
                    Abbreviation = "AAL",
                    CountryId = 2
                }, new Airline
                {
                    AirlineId = new Guid("cac3d5f7-43d8-4d71-9041-c2cae939d311"),
                    Name = "British Airways",
                    Abbreviation = "BRA",
                    CountryId = 3
                }, new Airline
                {
                    AirlineId = new Guid("3c8ae801-6e2e-42d9-9254-277b284d72c5"),
                    Name = "Virgin Atlantic",
                    Abbreviation = "VRA",
                    CountryId = 3
                }, new Airline
                {
                    AirlineId = new Guid("6739c7b3-b0f4-42ac-a8c8-7732cb4983e8"),
                    Name = "Japan Airlines",
                    Abbreviation = "JAL",
                    CountryId = 4
                }, new Airline
                {
                    AirlineId = new Guid("75c8b747-e2de-4aa7-a6d4-f19e6816244b"),
                    Name = "All Nippon Airways",
                    Abbreviation = "ANA",
                    CountryId = 4
                });
        }
    }
}

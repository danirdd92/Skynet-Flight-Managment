using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skynet.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skynet.Entities.SeedingConfigurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(
                new Country
                {
                    CountryId = 1,
                    Name = "Israel"
                },
                new Country
                {
                    CountryId = 2,
                    Name = "USA"
                },
                new Country
                {
                    CountryId = 3,
                    Name = "UK"
                },
                new Country
                {
                    CountryId = 4,
                    Name = "Japan"
                }
                );
        }
    }
}

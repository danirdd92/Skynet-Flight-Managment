﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Skynet.Entities.Extentions;
using Skynet.Entities.Models;
using Skynet.Entities.SeedingConfigurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skynet.Entities
{
    public class SkynetContext : IdentityDbContext<User>
    {


        public SkynetContext(DbContextOptions<SkynetContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Airline> Airlines { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Flight> Flights { get; set; }
        public virtual DbSet<UserFlights> UserFlights { get; set; }
        public override DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.BuildModels();

            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new AirlineConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            
        }

    }
}


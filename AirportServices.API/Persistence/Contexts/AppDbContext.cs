using Microsoft.EntityFrameworkCore;
using AirportServices.API.Domain.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System;

namespace AirportServices.API.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Airport> Airports { get; set; }
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            //Since we are reading Airport settings from JSON file for time being and not database.
            List<Airport> airportsSettings = new List<Airport>();
            builder.Entity<Airport>().ToTable("Airports");

            using (StreamReader sr = new StreamReader("Settings.json"))
            {
                string data = sr.ReadToEnd();
                airportsSettings = JsonConvert.DeserializeObject<List<Airport>>(data);
            }
            builder.Entity<Airport>().HasKey(a => a.AirportName);
            builder.Entity<Airport>().HasData(airportsSettings.ToArray());
        }
    }

}
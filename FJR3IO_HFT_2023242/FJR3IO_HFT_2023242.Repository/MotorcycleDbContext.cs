using System.Collections.Generic;
using System.Reflection.Emit;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace FJR3IO_HFT_2023242.Repository
{
    public class MotorcycleDbContext : DbContext
    {
        public DbSet<Motorcycle> Motorcycles { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Garage> Garages { get; set; }

        public MotorcycleDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder
                    .UseLazyLoadingProxies()
                    .UseInMemoryDatabase("motorcycles");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Motorcycle>(motorcycle => motorcycle
                .HasOne(motorcycle => motorcycle.Manufacturer)
                .WithMany(manufacturer => manufacturer.Motorcycles)
                .HasForeignKey(motorcycle => motorcycle.ManufacturerID)
                .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Motorcycle>(motorcycle => motorcycle
                .HasOne(motorcycle => motorcycle.Garage)
                .WithMany(garage => garage.Motorcycles)
                .HasForeignKey(motorcycle => motorcycle.GarageID)
                .OnDelete(DeleteBehavior.Cascade));



            modelBuilder.Entity<Motorcycle>().HasData(new Motorcycle[]
            {

                new Motorcycle("1#Harley-Davidson Sportster#2000#1#1"),
                new Motorcycle("2#Ducati Monster#2015#2#2"),
                new Motorcycle("3#Yamaha YZF-R1#2020#3#3"),
                new Motorcycle("4#Honda CBR1000RR#2021#4#4"),
                new Motorcycle("5#Suzuki GSX-R1000#2019#5#5"),
                new Motorcycle("6#Kawasaki Ninja ZX-10R#2022#3#6"),
                new Motorcycle("7#Triumph Bonneville#1961#7#7"),
                new Motorcycle("8#Yamaha WR-250X#2009#3#3")

            });

             modelBuilder.Entity<Manufacturer>().HasData(new Manufacturer[]
             {

                new Manufacturer("1#Yamaha"),
                new Manufacturer("2#Ducati"),
                new Manufacturer("3#Kawasaki"),
                new Manufacturer("4#Honda"),
                new Manufacturer("5#Suzuki"),
                new Manufacturer("6#Harley-Davidson"),
                new Manufacturer("7#Triumph")

             });

             modelBuilder.Entity<Garage>().HasData(new Garage[]
             {
                new Garage("1#Joe's Motorcycles"),
                new Garage("2#Fast Bikes Garage"),
                new Garage("3#Speedy's Motorcycle Shop"),
                new Garage("4#Rider's Paradise"),
                new Garage("5#Two Wheels Good")
             });

        }
    }
}

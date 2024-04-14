using System;
using Microsoft.EntityFrameworkCore;
using FJR3IO_HFT_2023242.Repository;
using FJR3IO_HFT_2023242.Models;
using System.Linq;

namespace FJR3IO_HFT_2023242
{
    class Program
    {
        static void Main(string[] args)
        {
            MotorcycleDbContext mocik = new MotorcycleDbContext();
            ;

            // Create an instance of MotorcycleDbContext
            using (var dbContext = new MotorcycleDbContext())
            {
                // Ensure the database is created (if it doesn't exist)
                dbContext.Database.EnsureCreated();

                // Example: Retrieve all motorcycles from the database
                var motorcycles = dbContext.Motorcycles.ToList();
                foreach (var motorcycle in motorcycles)
                {
                    Console.WriteLine($"ID: {motorcycle.MotorcycleID}, Model: {motorcycle.Model}, Year: {motorcycle.ManufacturingYear}");
                }

                // Example: Add a new motorcycle to the database
                var newMotorcycle = new Motorcycle("9#BMW S1000RR#2022#8#2");
                dbContext.Motorcycles.Add(newMotorcycle);
                dbContext.SaveChanges();

                Console.WriteLine("New motorcycle added to the database.");

                // Example: Update an existing motorcycle
                var motorcycleToUpdate = dbContext.Motorcycles.Find(1);
                if (motorcycleToUpdate != null)
                {
                    motorcycleToUpdate.Model = "Updated Model";
                    dbContext.SaveChanges();
                    Console.WriteLine("Motorcycle updated.");
                }

                // Example: Delete a motorcycle
                var motorcycleToDelete = dbContext.Motorcycles.Find(2);
                if (motorcycleToDelete != null)
                {
                    dbContext.Motorcycles.Remove(motorcycleToDelete);
                    dbContext.SaveChanges();
                    Console.WriteLine("Motorcycle deleted.");
                }
            }
        }
    }
}

using System;
using System.Linq;
using System.Collections.Generic;
using FJR3IO_HFT_2023242.Models;
using FJR3IO_HFT_2023242.Repository;


namespace FJR3IO_HFT_2023242.Logic
{
    public class MotorcycleLogic : IMotorcycleLogic
    {
        IRepository<Motorcycle> repository;

        public MotorcycleLogic(IRepository<Motorcycle> repository)
        {
            this.repository = repository;
        }

        public void Create(Motorcycle item)
        {
            if (string.IsNullOrEmpty(item.Model))
            {
                throw new ArgumentException("The model of the motorcycle is empty!");
            }
            this.repository.Create(item);
        }

        public void Delete(int id)
        {
            this.repository.Delete(id);
        }

        public Motorcycle Read(int id)
        {
            var motorcycle = this.repository.Read(id);
            if (motorcycle == null)
            {
                throw new ArgumentException("This motorcycle does not exist!");
            }
            return motorcycle;
        }

        public IQueryable<Motorcycle> ReadAll()
        {
            return this.repository.ReadAll();
        }

        public void Update(Motorcycle item)
        {
            this.repository.Update(item);
        }

        // Non-CRUD methods
        public int GetMotorcycleCountByManufacturer(string manufacturerName)
        {
            return this.repository
                .ReadAll()
                .Where(m => m.Manufacturer.ManufacturerName == manufacturerName)
                .Count();
        }

        public int GetMotorcycleCountByYear(int year)
        {
            return this.repository
                .ReadAll()
                .Where(m => m.ManufacturingYear == year)
                .Count();
        }

        public IEnumerable<string> GetMotorcycleModelsByManufacturer(string manufacturerName)
        {
            return this.repository
                .ReadAll()
                .Where(m => m.Manufacturer.ManufacturerName == manufacturerName)
                .Select(m => m.Model);
        }

        public IEnumerable<string> GetMotorcycleModelsByGarage(string garageName)
        {
            return this.repository
                .ReadAll()
                .Where(m => m.Garage.GarageName == garageName)
                .Select(m => m.Model);
        }

        public IEnumerable<string> GetGarageNamesByManufacturer(string manufacturerName)
        {
            return this.repository
                .ReadAll()
                .Where(m => m.Manufacturer.ManufacturerName == manufacturerName)
                .Select(m => m.Garage.GarageName);
        }
    }
}

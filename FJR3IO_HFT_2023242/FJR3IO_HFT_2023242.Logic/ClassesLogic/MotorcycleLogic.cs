using System;
using System.Collections.Generic;
using System.Linq;
using FJR3IO_HFT_2023242.Models;
using FJR3IO_HFT_2023242.Repository;

namespace FJR3IO_HFT_2023242.Logic
{
    public class MotorcycleLogic : IMotorcycleLogic
    {
        private readonly IRepository<Motorcycle> repository;

        public MotorcycleLogic(IRepository<Motorcycle> repository)
        {
            this.repository = repository;
        }

        // Existing CRUD methods

        public void Create(Motorcycle item)
        {
            if (string.IsNullOrEmpty(item.Model))
            {
                throw new ArgumentException("The model of the motorcycle is empty!");
            }
            repository.Create(item);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public Motorcycle Read(int id)
        {
            var motorcycle = repository.Read(id);
            if (motorcycle == null)
            {
                throw new ArgumentException("This motorcycle does not exist!");
            }
            return motorcycle;
        }

        public IQueryable<Motorcycle> ReadAll()
        {
            return repository.ReadAll();
        }

        public void Update(Motorcycle item)
        {
            repository.Update(item);
        }

        // Non-CRUD methods

        public int GetMotorcycleNumberByManufacturer(string manufacturerName)
        {
            return repository.ReadAll().Count(m => m.Manufacturer.ManufacturerName == manufacturerName);
        }

        public int GetMotorcycleNumberByYear(int year)
        {
            return repository.ReadAll().Count(m => m.ManufacturingYear == year);
        }

        public IEnumerable<string> GetMotorcycleTitleByManufacturer(string name)
        {
            return repository.ReadAll()
                .Where(m => m.Manufacturer.ManufacturerName == name)
                .Select(m => m.Model);
        }

        public IEnumerable<string> GetMotorcycleTitleByGarageName(string garageName)
        {
            return repository.ReadAll()
                .Where(m => m.Garage.GarageName == garageName)
                .Select(m => m.Model);
        }

        public IEnumerable<string> GetGarageNameByManufacturerName(string name)
        {
            return repository.ReadAll()
                .Where(m => m.Manufacturer.ManufacturerName == name)
                .Select(m => m.Garage.GarageName);
        }
    }
}

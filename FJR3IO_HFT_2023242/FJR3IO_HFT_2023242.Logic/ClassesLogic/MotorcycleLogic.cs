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

        // CRUD 

        public void Create(Motorcycle item)
        {
            if ( item.Model.Length <= 1 || string.IsNullOrEmpty(item.Model))
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

        // Non-CRUD 

        public int GetMotorcycleNumberByManufacturer(string manufacturerName)
        {
            return this.repository
                .ReadAll()
                .Where(t => t.Manufacturer.ManufacturerName == manufacturerName)
                .Count();
        }

        public int GetMotorcycleNumberByYear(int year)
        {
            return this.repository
                .ReadAll()
                .Count(m => m.ManufacturingYear == year);
        }

        public IEnumerable<string> GetMotorcycleModelByManufacturer(string name)
        {
            return this.repository
                .ReadAll()
                .Where(m => m.Manufacturer.ManufacturerName == name)
                .Select(b => b.Model);

        }

        public IEnumerable<string> GetMotorcycleModelByGarageName(string garageName)
        {
            return this.repository
                .ReadAll()
                .Where(m => m.Garage.GarageName == garageName)
                .Select(m => m.Model);
        }

        public IEnumerable<string> GetGarageNameByManufacturerName(string name)
        {
            return this.repository
                .ReadAll()
                .Where(m => m.Manufacturer.ManufacturerName == name)
                .Select(m => m.Garage.GarageName);
        }
    }
}

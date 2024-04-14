using System;
using System.Linq;
using FJR3IO_HFT_2023242.Models;
using FJR3IO_HFT_2023242.Repository;

namespace FJR3IO_HFT_2023242.Logic
{
    public class ManufacturerLogic : IManufacturerLogic
    {
        IRepository<Manufacturer> repository;

        public ManufacturerLogic(IRepository<Manufacturer> repository)
        {
            this.repository = repository;
        }

        public void Create(Manufacturer item)
        {
            if (item.ManufacturerName.Length <= 1)
            {
                throw new ArgumentException("The name of the manufacturer is too short!");
            }
            this.repository.Create(item);
        }

        public void Delete(int id)
        {
            this.repository.Delete(id);
        }

        public Manufacturer Read(int id)
        {
            var manufacturer = this.repository.Read(id);
            if (manufacturer == null)
            {
                throw new ArgumentException("This manufacturer does not exist!");
            }
            return manufacturer;
        }

        public IQueryable<Manufacturer> ReadAll()
        {
            return this.repository.ReadAll();
        }

        public void Update(Manufacturer item)
        {
            this.repository.Update(item);
        }
    }
}

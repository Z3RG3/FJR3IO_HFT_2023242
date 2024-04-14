using System;
using System.Linq;
using FJR3IO_HFT_2023242.Models;
using FJR3IO_HFT_2023242.Repository;

namespace FJR3IO_HFT_2023242.Logic
{
    public class GarageLogic : IGarageLogic
    {
        IRepository<Garage> repository;

        public GarageLogic(IRepository<Garage> repository)
        {
            this.repository = repository;
        }

        public void Create(Garage item)
        {
            if (item.GarageName.Length <= 1)
            {
                throw new ArgumentException("The name of the garage is too short!");
            }
            this.repository.Create(item);
        }

        public void Delete(int id)
        {
            this.repository.Delete(id);
        }

        public Garage Read(int id)
        {
            var garage = this.repository.Read(id);
            if (garage == null)
            {
                throw new ArgumentException("This garage doesn`t seem to exist.");
            }
            return garage;
        }

        public IQueryable<Garage> ReadAll()
        {
            return this.repository.ReadAll();
        }

        public void Update(Garage item)
        {
            this.repository.Update(item);
        }
    }
}

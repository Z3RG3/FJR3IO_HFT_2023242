using System;
using FJR3IO_HFT_2023242.Models;
using System.Linq;

namespace FJR3IO_HFT_2023242.Logic
{
    public interface IMotorcycleLogic
    {
        IQueryable<Motorcycle> ReadAll();
        Motorcycle Read(int id);
        void Create(Motorcycle item);
        void Update(Motorcycle item);
        void Delete(int id);
    }
}

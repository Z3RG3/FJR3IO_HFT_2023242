using System;
using FJR3IO_HFT_2023242.Models;
using System.Linq;

namespace FJR3IO_HFT_2023242.Logic
{
    public interface IGarageLogic
    {
        IQueryable<Garage> ReadAll();
        Garage Read(int id);
        void Create(Garage item);
        void Update(Garage item);
        void Delete(int id);
    }
}

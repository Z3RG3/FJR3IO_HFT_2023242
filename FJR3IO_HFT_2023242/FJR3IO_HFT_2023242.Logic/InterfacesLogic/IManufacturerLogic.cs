using System;
using FJR3IO_HFT_2023242.Models;
using System.Linq;

namespace FJR3IO_HFT_2023242.Logic
{
    public interface IManufacturerLogic
    {
        IQueryable<Manufacturer> ReadAll();
        Manufacturer Read(int id);
        void Create(Manufacturer item);
        void Update(Manufacturer item);
        void Delete(int id);
    }
}

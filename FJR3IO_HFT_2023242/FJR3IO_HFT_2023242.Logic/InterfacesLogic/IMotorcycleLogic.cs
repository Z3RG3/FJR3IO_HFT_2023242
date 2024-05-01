using System;
using FJR3IO_HFT_2023242.Models;
using System.Linq;
using System.Collections.Generic;

namespace FJR3IO_HFT_2023242.Logic
{
    public interface IMotorcycleLogic
    {
        IQueryable<Motorcycle> ReadAll();
        Motorcycle Read(int id);
        void Create(Motorcycle item);
        void Update(Motorcycle item);
        void Delete(int id);
        int GetMotorcycleNumberByManufacturer(string name);
        int GetMotorcycleNumberByYear(int year);
        IEnumerable<string> GetMotorcycleTitleByGarageName(string garageName);
        IEnumerable<string> GetMotorcycleTitleByManufacturer(string name);
        IEnumerable<string> GetGarageNameByManufacturerName(string name);
    }
}

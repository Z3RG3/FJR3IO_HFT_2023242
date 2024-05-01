using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FJR3IO_HFT_2023242.Logic;
using Microsoft.AspNetCore.Mvc;

namespace FJR3IO_HFT_2023242.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        private readonly IMotorcycleLogic logic;

        public StatController(IMotorcycleLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet("{name}")]
        public int GetMotorcycleNumberByManufacturerStat(string name)
        {
            return this.logic.GetMotorcycleNumberByManufacturer(name); 
        }

        [HttpGet("{year}")]
        public int GetMotorcycleNumberByYearStat(int year)
        {
            return this.logic.GetMotorcycleNumberByYear(year);
        }

        [HttpGet("{name}")]
        public IEnumerable<string> GetMotorcycleModelByManufacturerStat(string name)
        {
            return this.logic.GetMotorcycleModelByManufacturer(name);
        }

        [HttpGet("{garageName}")]
        public IEnumerable<string> GetMotorcycleModelByGarageNameStat(string garageName)
        {
            return this.logic.GetMotorcycleModelByGarageName(garageName);
        }

        [HttpGet("{name}")]
        public IEnumerable<string> GetGarageNameByManufacturerNameStat(string name)
        {
            return this.logic.GetGarageNameByManufacturerName(name);
        }
    }
}

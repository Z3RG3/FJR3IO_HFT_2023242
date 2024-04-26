using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using FJR3IO_HFT_2023242.Logic;
using FJR3IO_HFT_2023242.Models;
using Microsoft.AspNetCore.Mvc;


namespace FJR3IO_HFT_2023242.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturerController : ControllerBase
    {
        IManufacturerLogic logic;
        public ManufacturerController(IManufacturerLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Manufacturer> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Manufacturer Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Manufacturer value)
        {
            this.logic.Create(value);
        }

        [HttpPut]
        public void Put([FromBody] Manufacturer value)
        {
            this.logic.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}

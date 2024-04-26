using System;
using FJR3IO_HFT_2023242.Logic;
using FJR3IO_HFT_2023242.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace FJR3IO_HFT_2023242.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GarageController : ControllerBase
    {
        private readonly IGarageLogic logic;

        public GarageController(IGarageLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Garage> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Garage Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Garage value)
        {
            this.logic.Create(value);
        }

        [HttpPut]
        public void Put([FromBody] Garage value)
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


using System.Collections.Generic;
using FJR3IO_HFT_2023242.Logic;
using FJR3IO_HFT_2023242.Models;
using Microsoft.AspNetCore.Mvc;

namespace FJR3IO_HFT_2023242.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotorcycleController : ControllerBase
    {
        private readonly IMotorcycleLogic logic;

        public MotorcycleController(IMotorcycleLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Motorcycle> ReadAll()
        {
            return logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Motorcycle Read(int id)
        {
            return logic.Read(id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Motorcycle value)
        {
            logic.Create(value);
            return Ok();
        }

        [HttpPut]
        public IActionResult Put([FromBody] Motorcycle value)
        {
            logic.Update(value);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            logic.Delete(id);
            return Ok();
        }
    }
}

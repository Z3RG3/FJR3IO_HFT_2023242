using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FJR3IO_HFT_2023242.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotorController : ControllerBase
    {
        // GET: api/<MotorController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<MotorController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MotorController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MotorController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MotorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

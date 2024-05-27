using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tournament.Core.Entities;


namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourneysController : ControllerBase
    {
        // GET: api/<TourneysController>
        [HttpGet]
        public IEnumerable<Game> Get()
        {
            return new List<Game>();
        }

        // GET api/<TourneysController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TourneysController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TourneysController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TourneysController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

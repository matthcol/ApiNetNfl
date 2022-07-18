using ApiNFL.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiNFL.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Team> Get()
        {
            return new Team[] { 
                new Team { Id=1, Name="Seahawks", City="Seattle", Conference = ConferenceEnum.East, CreationDate = System.DateTime.Today},
                new Team { Id=2, Name="Patriots", City="New England", Conference = ConferenceEnum.West, CreationDate = new System.DateTime(1950, 6, 12)},
            };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id:int}")]
        // public Team Get([FromRoute] int id)
        public Team Get([FromRoute] int id)
        {
            return new Team { Id = id, Name = "Seahawks", City = "Seattle" };
        }

        [HttpGet("{name}")]
        // public Team Get([FromRoute] int id)
        public Team GetByName([FromRoute] string name)
        {
            return new Team { Id = 1, Name = name, City = "Seattle" };
        }

        [HttpGet("byYear")]
        public IEnumerable<Team> GetByYear([FromQuery(Name="y")] int? year)
        {
            return new Team[] {
                new Team { Id=year, Name="Seahawks", City="Seattle"},
                new Team { Id=year, Name="Patriots", City="New England"},
            };
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] Team team)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Team team)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

    }
}

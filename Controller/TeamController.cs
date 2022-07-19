using ApiNFL.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Mime;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiNFL.Controller
{
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Team> Get()
        {
            return new Team[] { 
                new Team { 
                    Id=1, 
                    Name="Seahawks", 
                    City="Seattle", 
                    Conference = ConferenceEnum.East, 
                    CreationDate = System.DateTime.Today,
                    Sponsor = "Koca Kola"
                },
                new Team { Id=2, Name="Patriots", City="New England", Conference = ConferenceEnum.West, 
                    CreationDate = new System.DateTime(1950, 6, 12),
                    Sponsor = "Pepsy Kola"
                },
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
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<Team> Post([FromBody] Team team)
        {
            team.Id = 1;
            return Created(nameof(Post), team);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Put(int id, [FromBody] Team team)
        {
            // simulate id not exists
            if (id < 1)
            {
                return NotFound($"Team not found with id {id}");
            } else if (id != team.Id)
            {
                return BadRequest($"ids don't match: {id}, {team.Id}");
            }
            return NoContent();
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

    }
}

﻿using ApiNFL.Enumeration;
using ApiNFL.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Mime;
using ApiNFL.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiNFL.Controller
{
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService; 
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<TeamViewModel> Get()
        {
            return new TeamViewModel[] { 
                new TeamViewModel { 
                    Id=1, 
                    Name="Seahawks", 
                    City="Seattle", 
                    Conference = ConferenceEnum.East, 
                    CreationDate = System.DateTime.Today,
                    Sponsor = "Koca Kola"
                },
                new TeamViewModel { Id=2, Name="Patriots", City="New England", Conference = ConferenceEnum.West, 
                    CreationDate = new System.DateTime(1950, 6, 12),
                    Sponsor = "Pepsy Kola"
                },
            };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id:int}")]
        // public Team Get([FromRoute] int id)
        public ActionResult<TeamDetailViewModel> Get([FromRoute] int id)
        {
            //return new TeamDetailViewModel { 
            //    Id = id, Name = "Seahawks", City = "Seattle", 
            //    Players = new List<PlayerViewModel> { 
            //        new PlayerViewModel
            //        {
            //            Id = 1,
            //            Name = "Tom Brady"
            //        },
            //        new PlayerViewModel {
            //            Id = 1,
            //            Name = "Russel Wilson"
            //        }
            //    } };
            var teamViewModel =  _teamService.GetById(id);
            //if (teamViewModel == null)
            //{
            //    //return Ok("No Team with this Id");
            //    return NotFound($"No Team with id: {id}");
            //}
            return teamViewModel;
        }

        [HttpGet("{name}")]
        // public Team Get([FromRoute] int id)
        public TeamViewModel GetByName([FromRoute] string name)
        {
            // return new TeamViewModel { Id = 1, Name = name, City = "Seattle" };
            //var team = _DbContext.Teams.Find(1);
            //return new TeamViewModel { Name = team.Name, CreationDate = team.CreationDate };
            return null;
        }

        [HttpGet("byYear")]
        public IEnumerable<TeamViewModel> GetByYear([FromQuery(Name="y")] int? year)
        {
            return new TeamViewModel[] {
                new TeamViewModel { Id=year, Name="Seahawks", City="Seattle"},
                new TeamViewModel { Id=year, Name="Patriots", City="New England"},
            };
        }

        // POST api/<ValuesController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<TeamViewModel> Post([FromBody] TeamViewModel team)
        {
            //_DbContext.Teams.Add(new Team { Name = team.Name, City=team.Name, CreationDate = team.CreationDate });
            //_DbContext.SaveChanges();
            var teamSaved = _teamService.Save(team);
            return Created(nameof(Post), teamSaved);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Put(int id, [FromBody] TeamViewModel team)
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

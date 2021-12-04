using FootballManager.Entities;
using FootballManager.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Team>>> GetTeams()
        {
            IEnumerable<Team> teams = await _teamService.GetAllAsync();
            return Ok(teams);
        }

        [HttpGet("{id}")]
        public ActionResult<Team> FindTeam(int id)
        {
            var team = _teamService.Get(x => x.Id == id).FirstOrDefault();
            return Ok(team);
        }

        [HttpPost]
        public async Task<IActionResult> AddTeam(Team team)
        {
            await _teamService.AddAsync(team);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateTeam(Team team)
        {
            _teamService.Update(team);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            Team existTeam = await _teamService.SingleOrDefaultAsync(x => x.Id == id);
            if (existTeam != null)
            {
                _teamService.Remove(existTeam);
                return NoContent();
            }

            return BadRequest();

        }
    }
}

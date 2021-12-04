using AutoMapper;
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
    public class CoachController : ControllerBase
    {
        private ICoachService _coachService;

        public CoachController(ICoachService coachService)
        {
            _coachService = coachService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Coach>>> GetFootballers()
        {
            IEnumerable<Coach> coaches = await _coachService.GetAllAsync();
            return Ok(coaches);
        }

        [HttpGet("{id}")]
        public ActionResult<Coach> FindCoach(int id)
        {
            var coach = _coachService.Get(x => x.Id == id).FirstOrDefault();
            return Ok(coach);
        }

        [HttpPost]
        public async Task<IActionResult> AddCoach(Coach coach)
        {
            await _coachService.AddAsync(coach);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateCoach(Coach coach)
        {
            _coachService.Update(coach);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoach(int id)
        {
            Coach existCoach = await _coachService.SingleOrDefaultAsync(x => x.Id == id);
            if (existCoach != null)
            {
                _coachService.Remove(existCoach);
                return NoContent();
            }

            return BadRequest();

        }

    }
}

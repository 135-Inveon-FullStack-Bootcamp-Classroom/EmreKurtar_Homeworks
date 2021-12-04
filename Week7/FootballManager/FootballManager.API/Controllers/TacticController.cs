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
    public class TacticController : ControllerBase
    {
        private ITacticService _tacticService;

        public TacticController(ITacticService tacticService)
        {
            _tacticService = tacticService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tactic>>> GetTactic()
        {
            IEnumerable<Tactic> tactics = await _tacticService.GetAllAsync();
            return Ok(tactics);
        }

        [HttpGet("{id}")]
        public ActionResult<Tactic> FindTactic(int id)
        {
            var tactic = _tacticService.Get(x => x.Id == id).FirstOrDefault();
            return Ok(tactic);
        }

        [HttpPost]
        public async Task<IActionResult> AddTactic(Tactic tactic)
        {
            await _tacticService.AddAsync(tactic);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateTactic(Tactic tactic)
        {
            _tacticService.Update(tactic);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTactic(int id)
        {
            Tactic existTactic = await _tacticService.SingleOrDefaultAsync(x => x.Id == id);
            if (existTactic != null)
            {
                _tacticService.Remove(existTactic);
                return NoContent();
            }

            return BadRequest();

        }
    }
}

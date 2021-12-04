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
    public class PositionController : ControllerBase
    {
        private IPositionService _positionService;

        public PositionController(IPositionService positionService)
        {
            _positionService = positionService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Position>>> GetPositions()
        {
            IEnumerable<Position> positions = await _positionService.GetAllAsync();
            return Ok(positions);
        }

        [HttpGet("{id}")]
        public ActionResult<Position> FindPosition(int id)
        {
            var position = _positionService.Get(x => x.Id == id).FirstOrDefault();
            return Ok(position);
        }

        [HttpPost]
        public async Task<IActionResult> AddPosition(Position position)
        {
            await _positionService.AddAsync(position);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdatePosition(Position position)
        {
            _positionService.Update(position);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePosition(int id)
        {
            Position existPosition = await _positionService.SingleOrDefaultAsync(x => x.Id == id);
            if (existPosition != null)
            {
                _positionService.Remove(existPosition);
                return NoContent();
            }

            return BadRequest();

        }
    }
}

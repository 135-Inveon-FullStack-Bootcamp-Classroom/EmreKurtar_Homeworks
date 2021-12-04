using AutoMapper;
using FootballManager.Entities;
using FootballManager.Service.DTOs.Footballer;
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
    public class FootballerController : ControllerBase
    {
        private IFootballerService _footballerService;
        private IMapper _mapper;

        public FootballerController(IFootballerService footballerService,IMapper mapper)
        {
            _footballerService = footballerService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Footballer>>> GetFootballers()
        {
            IEnumerable<Footballer> footballer = await _footballerService.GetAllAsync();
            return Ok(footballer);
        }

        [HttpGet("{id}")]
        public ActionResult<Footballer> FindFootballer(int id)
        {
            var footballer = _footballerService.Get(x => x.Id == id).FirstOrDefault(); 
            return Ok(footballer);
        }

        [HttpPost]
        public async Task<IActionResult> AddFootballer(AddFootballerDTO footballerdto)
        {
            await _footballerService.AddAsync(_mapper.Map<Footballer>(footballerdto));
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateFootballer(UpdateFootballerDTO footballerdto)
        {
             _footballerService.Update(_mapper.Map<Footballer>(footballerdto));
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFootballer(int id)
        {
            Footballer existFootballer = await _footballerService.SingleOrDefaultAsync(x => x.Id == id);
            if(existFootballer != null)
            {
                _footballerService.Remove(existFootballer);
                return NoContent();
            }

            return BadRequest();
            
        }




    }
}

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


    }
}

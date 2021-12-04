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
    public class ManagerController : ControllerBase
    {
        private IManagerService _managerService;

        public ManagerController(IManagerService managerService)
        {
            _managerService = managerService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Manager>>> GetManagers()
        {
            IEnumerable<Manager> managers = await _managerService.GetAllAsync();
            return Ok(managers);
        }

        [HttpGet("{id}")]
        public ActionResult<Manager> FindManager(int id)
        {
            var manager = _managerService.Get(x => x.Id == id).FirstOrDefault();
            return Ok(manager);
        }

        [HttpPost]
        public async Task<IActionResult> AddManager(Manager manager)
        {
            await _managerService.AddAsync(manager);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateManager(Manager manager)
        {
            _managerService.Update(manager);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManager(int id)
        {
            Manager existManager = await _managerService.SingleOrDefaultAsync(x => x.Id == id);
            if (existManager != null)
            {
                _managerService.Remove(existManager);
                return NoContent();
            }

            return BadRequest();

        }
    }
}

using Microsoft.AspNetCore.Mvc;
using PrivateTaskerAPI.Models;
using PrivateTaskerAPI.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrivateTaskerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReminderController : ControllerBase
    {
        private readonly IReminderService _reminderService;

        public ReminderController(IReminderService reminderService)
        {
            _reminderService = reminderService;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _reminderService.Delete(id);
            if (result)
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Reminder>> GetById([FromRoute] int id)
        {
            var reminderDto = await _reminderService.GetById(id);
            return Ok(reminderDto);
        } 
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reminder>>> GetAll()
        {
            var reminderDtos = await _reminderService.GetAll();
            return Ok(reminderDtos);
        }

        [HttpPost]
        public async Task<ActionResult> Create(ReminderDTO reminderDto)
        {
            await _reminderService.Create(reminderDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromRoute]int id, [FromBody]ReminderDTO reminderDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _reminderService.Update(id, reminderDto);
            if (result)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}

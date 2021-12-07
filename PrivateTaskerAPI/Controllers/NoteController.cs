using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PrivateTaskerAPI.Models;
using PrivateTaskerAPI.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrivateTaskerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NoteController : ControllerBase
    {
        private readonly ILogger<NoteController> _logger;
        private readonly INoteService _noteService;

        public NoteController(ILogger<NoteController> logger, INoteService noteService)
        {
            _noteService = noteService;
            _logger = logger;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _noteService.Delete(id);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] NoteDTO noteDto)
        {
            await _noteService.Create(noteDto);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Note>>> GetAll()
        {
            var notes = await _noteService.GetAll();
            return Ok(notes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Note>> GetById([FromRoute] int id)
        {
            var note = await _noteService.GetById(id);
            return Ok(note);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromRoute] int id, [FromBody] NoteDTO noteDto)
        {
            await _noteService.Update(id, noteDto);
            return Ok();
        }
    }
}

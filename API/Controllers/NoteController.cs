using API_MySIRH.DTOs;
using API_MySIRH.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API_MySIRH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly INoteservice _Noteservice;

        public NoteController(INoteservice Noteervice)
        {
            this._Noteservice = Noteervice;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NoteDTO>>> GetNotes()
        {
            var result = await this._Noteservice.GetNotes();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NoteDTO>> GetNote(int id)
        {
            return Ok(await this._Noteservice.GetNote(id));
        }

        [HttpPost]
        public async Task<ActionResult> AddNote(NoteDTO NoteDTO)
        {
            var NoteToCreate = await this._Noteservice.AddNote(NoteDTO);
            return CreatedAtAction(nameof(GetNote), new { id = NoteToCreate.Id }, NoteToCreate);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<NoteDTO>> UpdateNote(int id, NoteDTO NoteDTO)
        {
            if (id != NoteDTO.Id)
            {
                return BadRequest();
            }
            try
            {
                await this._Noteservice.UpdateNote(id, NoteDTO);
            }
            catch
            {
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNote(int id)
        {
            var Note = await this._Noteservice.GetNote(id);
            if (Note is null)
                return NotFound();
            await this._Noteservice.DeleteNote(id);
            return NoContent();
        }


        [HttpGet("findNoteByTemplate/{id}")]
        public async Task<ActionResult<NoteDTO>> findNoteByTemplate(int id)
        {
            return Ok(await this._Noteservice.findNoteByTemplate(id));
        }
    }
}

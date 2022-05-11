using API_MySIRH.DTOs;
using API_MySIRH.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API_MySIRH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommenterController : ControllerBase
    {
        private readonly INoteservice _Noteservice;

        public CommenterController(INoteservice Commenterervice)
        {
            this._Noteservice = Commenterervice;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NoteDTO>>> GetNotes()
        {
            var result = await this._Noteservice.GetNotes();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NoteDTO>> GetCommenter(int id)
        {
            return Ok(await this._Noteservice.GetCommenter(id));
        }

        [HttpPost]
        public async Task<ActionResult> AddCommenter(NoteDTO CommenterDTO)
        {
            var CommenterToCreate = await this._Noteservice.AddCommenter(CommenterDTO);
            return CreatedAtAction(nameof(GetCommenter), new { id = CommenterToCreate.Id }, CommenterToCreate);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<NoteDTO>> UpdateCommenter(int id, NoteDTO CommenterDTO)
        {
            if (id != CommenterDTO.Id)
            {
                return BadRequest();
            }
            try
            {
                await this._Noteservice.UpdateCommenter(id, CommenterDTO);
            }
            catch
            {
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommenter(int id)
        {
            var Commenter = await this._Noteservice.GetCommenter(id);
            if (Commenter is null)
                return NotFound();
            await this._Noteservice.DeleteCommenter(id);
            return NoContent();
        }
    }
}

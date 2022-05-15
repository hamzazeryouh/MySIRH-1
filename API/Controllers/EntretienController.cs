using API_MySIRH.DTOs;
using API_MySIRH.Interfaces.InterfaceServices;
using Microsoft.AspNetCore.Mvc;

namespace API_MySIRH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntretienController :ControllerBase
    {
        private readonly IEntretienService _EntretienService;

        public EntretienController(IEntretienService EntretienService)
        {
            this._EntretienService = EntretienService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EntretienDTO>>> GetEntretiens()
        {
            var result = await this._EntretienService.GetEntretiens();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EntretienDTO>> GetEntretien(int id)
        {
            return Ok(await this._EntretienService.GetEntretien(id));
        }

        [HttpPost]
        public async Task<ActionResult> AddEntretien(EntretienDTO EntretienDTO)
        {
            var EntretienToCreate = await this._EntretienService.AddEntretien(EntretienDTO);
            return CreatedAtAction(nameof(GetEntretiens), new { id = EntretienToCreate.Id }, EntretienToCreate);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EntretienDTO>> UpdateEntretien(int id, EntretienDTO EntretienDTO)
        {
            if (id != EntretienDTO.Id)
            {
                return BadRequest();
            }
            try
            {
                await this._EntretienService.UpdateEntretien(id, EntretienDTO);
            }
            catch
            {
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntretien(int id)
        {
            var Entretien = await this._EntretienService.GetEntretien(id);
            if (Entretien is null)
                return NotFound();
            await this._EntretienService.DeleteEntretien(id);
            return NoContent();
        }


        [HttpGet("ByCandidat/{id}")]

        public async Task<IActionResult> GetEvaluationByCandidat(int id)
        {
            return Ok(await _EntretienService.GetEntretienByCandidat(id));
        }
    }
}

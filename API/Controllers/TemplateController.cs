using API_MySIRH.DTOs;
using API_MySIRH.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API_MySIRH.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TemplateController : ControllerBase
    {
        private readonly ITemplateService _TemplateService;

        public TemplateController(ITemplateService Templateervice)
        {
            this._TemplateService = Templateervice;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TemplateDTO>>> GetTemplates()
        {
            var result = await this._TemplateService.GetTemplates();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TemplateDTO>> GetTemplate(int id)
        {
            return Ok(await this._TemplateService.GetTemplate(id));
        }

        [HttpPost]
        public async Task<ActionResult> AddTemplate(TemplateDTO TemplateDTO)
        {
            var TemplateToCreate = await this._TemplateService.AddTemplate(TemplateDTO);
            return CreatedAtAction(nameof(GetTemplate), new { id = TemplateToCreate.Id }, TemplateToCreate);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TemplateDTO>> UpdateTemplate(int id, TemplateDTO TemplateDTO)
        {
            if (id != TemplateDTO.Id)
            {
                return BadRequest();
            }
            try
            {
                await this._TemplateService.UpdateTemplate(id, TemplateDTO);
            }
            catch
            {
                throw;
            }

            return NoContent();
        }

        [HttpPut("Note/{id}")]
        public async Task<ActionResult<TemplateDTO>> UpdateTemplateNote(int id, TemplateNoteDTO TemplateDTO)
        {
            if (id != TemplateDTO.Id)
            {
                return BadRequest();
            }
            try
            {
                await this._TemplateService.UpdateTemplateNote(id, TemplateDTO);
            }
            catch
            {
                throw;
            }

            return NoContent();
        }





        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTemplate(int id)
        {
            var Template = await this._TemplateService.GetTemplate(id);
            if (Template is null)
                return NotFound();
            await this._TemplateService.DeleteTemplate(id);
            return NoContent();
        }
    }
}

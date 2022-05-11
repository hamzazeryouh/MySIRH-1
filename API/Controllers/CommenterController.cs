using API_MySIRH.DTOs;
using API_MySIRH.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API_MySIRH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommenterController : ControllerBase
    {
        private readonly ICommenterService _CommenterService;

        public CommenterController(ICommenterService Commenterervice)
        {
            this._CommenterService = Commenterervice;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommenterDTO>>> GetCommenters()
        {
            var result = await this._CommenterService.GetCommenters();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CommenterDTO>> GetCommenter(int id)
        {
            return Ok(await this._CommenterService.GetCommenter(id));
        }

        [HttpPost]
        public async Task<ActionResult> AddCommenter(CommenterDTO CommenterDTO)
        {
            var CommenterToCreate = await this._CommenterService.AddCommenter(CommenterDTO);
            return CreatedAtAction(nameof(GetCommenter), new { id = CommenterToCreate.Id }, CommenterToCreate);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CommenterDTO>> UpdateCommenter(int id, CommenterDTO CommenterDTO)
        {
            if (id != CommenterDTO.Id)
            {
                return BadRequest();
            }
            try
            {
                await this._CommenterService.UpdateCommenter(id, CommenterDTO);
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
            var Commenter = await this._CommenterService.GetCommenter(id);
            if (Commenter is null)
                return NotFound();
            await this._CommenterService.DeleteCommenter(id);
            return NoContent();
        }
    }
}

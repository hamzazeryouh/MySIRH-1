using API_MySIRH.DTOs;
using API_MySIRH.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API_MySIRH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvaluationController : ControllerBase
    {
        private readonly IEvaluationService _EvaluationService;


        public EvaluationController(IEvaluationService Evaluationervice)
        {
            this._EvaluationService = Evaluationervice;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EvaluationDTO>>> GetEvaluations()
        {
            var result = await this._EvaluationService.GetEvaluations();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EvaluationDTO>> GetEvaluation(int id)
        {
            return Ok(await this._EvaluationService.GetEvaluation(id));
        }

        [HttpPost]
        public async Task<ActionResult> AddEvaluation(EvaluationDTO EvaluationDTO)
        {

            var EvaluationToCreate = await this._EvaluationService.AddEvaluation(EvaluationDTO);
            return CreatedAtAction(nameof(GetEvaluation), new { id = EvaluationToCreate.Id }, EvaluationToCreate);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EvaluationDTO>> UpdateEvaluation(int id, EvaluationDTO EvaluationDTO)
        {
            if (id != EvaluationDTO.Id)
            {
                return BadRequest();
            }
            try
            {
                await this._EvaluationService.UpdateEvaluation(id, EvaluationDTO);
            }
            catch
            {
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvaluation(int id)
        {
            var Evaluation = await this._EvaluationService.GetEvaluation(id);
            if (Evaluation is null)
                return NotFound();
            await this._EvaluationService.DeleteEvaluation(id);
            return NoContent();
        }
        

        [HttpGet("ByCandidat/{id}")]

        public async Task<IActionResult> GetEvaluationByCandidat(int id)
        {
          return  Ok(await _EvaluationService.GetEvaluationByCandidat(id));
        }

    }
}

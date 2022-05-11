

namespace API_MySIRH.Interfaces
{


    using API_MySIRH.DTOs;
    using Microsoft.AspNetCore.Mvc;

    public interface IEvaluationService
    {
        Task<IEnumerable<EvaluationDTO>> GetEvaluations();
        Task<EvaluationDTO> GetEvaluation(int id);
        Task UpdateEvaluation(int id, EvaluationDTO Evaluation);
        Task<EvaluationDTO> AddEvaluation(EvaluationDTO Evaluation);
        Task DeleteEvaluation(int id);
        Task<dynamic> GetEvaluationByCandidat(int id);

    }
}

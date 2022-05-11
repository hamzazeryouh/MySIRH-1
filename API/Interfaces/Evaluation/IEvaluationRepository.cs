

namespace API_MySIRH.Interfaces
{


    using API_MySIRH.DTOs;
    using API_MySIRH.Entities.Evaluation;
    using Microsoft.AspNetCore.Mvc;

    public interface IEvaluationRepository
    {
        Task<IEnumerable<Evaluation>> GetEvaluations();
        Task<Evaluation> GetEvaluation(int id);
        Task UpdateEvaluation(int id, Evaluation Evaluation);
        Task<Evaluation> AddEvaluation(Evaluation Evaluation);
        Task DeleteEvaluation(int id);
        Task<bool> EvaluationExists(int id);
        Task<dynamic> GetEvaluationByCandidat(int candidatid);
    }
}

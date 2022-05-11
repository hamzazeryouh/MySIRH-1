

namespace API_MySIRH.Repositories
{
    using API_MySIRH.Data;
    using API_MySIRH.DTOs;
    using API_MySIRH.Entities.Evaluation;
    using API_MySIRH.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    public class EvaluationRepository: IEvaluationRepository
    {
        private readonly DataContext _context;


        public EvaluationRepository(DataContext context)
        {
            this._context = context;
        }

        public async Task<Evaluation> AddEvaluation(Evaluation Evaluation)
        {
            await this._context.Evaluations.AddAsync(Evaluation);
            await this._context.SaveChangesAsync();
            return Evaluation;
        }

        public async Task<bool> EvaluationExists(int id)
        {
            return await this._context.Evaluations.AnyAsync(Evaluation => Evaluation.Id == id);
        }

        public async Task DeleteEvaluation(int id)
        {
            var EvaluationToDelete = await this._context.Evaluations.FindAsync(id);
            if (EvaluationToDelete is not null)
                this._context.Evaluations.Remove(EvaluationToDelete);
            await this._context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Evaluation>> GetEvaluations()
        {
            return await this._context.Evaluations.ToListAsync();
        }

        public async Task<Evaluation> GetEvaluation(int id)
        {
            return await _context.Evaluations.FindAsync(id);
        }

        public async Task UpdateEvaluation(int id, Evaluation Evaluation)
        {
            this._context.Entry(Evaluation).State = EntityState.Modified;
            await this._context.SaveChangesAsync();
        }

        public async Task<dynamic> GetEvaluationByCandidat(int candidatid)
        {


       //where candidatid == Ev.Id

            var evaluation =await (from Ev in this._context.Evaluations   select (Ev)).FirstOrDefaultAsync();
            if (evaluation == null) return null;
            var Template = await (from Te in _context.Templates where Te.EvaluationId == evaluation.Id select new {Te.Id, Te.Note, Te.Them, Te.Title, Te.Technologie }).ToListAsync();
           // var Comment =await (from Co in _context.Commenters where Co.Id == evaluation.CommenterId select (Co)).FirstOrDefaultAsync();
            
            dynamic Result = new
            {
                evaluation,
                Template,
            };

            return Result;
        }


    }   
}

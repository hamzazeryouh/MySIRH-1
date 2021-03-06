using API_MySIRH.Data;
using API_MySIRH.Entities;
using API_MySIRH.Entities.Evaluation;
using API_MySIRH.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_MySIRH.Repositories
{
    public class EntretienRepository: IEntretienRepository
    {

        private readonly DataContext _context;

        public EntretienRepository(DataContext context)
        {
            this._context = context;
        }

        public async Task<Entretien> AddEntretien(Entretien Entretien)
        {
            await this._context.Entretiens.AddAsync(Entretien);
            await this._context.SaveChangesAsync();
            return Entretien;
        }
        public async Task DeleteEntretien(int id)
        {
            var EntretienToDelete = await this._context.Entretiens.FindAsync(id);
            if (EntretienToDelete is not null)
                this._context.Entretiens.Remove(EntretienToDelete);
            await this._context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Entretien>> GetEntretiens()
        {
            return await this._context.Entretiens.ToListAsync();
        }

        public async Task<Entretien> GetEntretien(int id)
        {
            return await _context.Entretiens.FindAsync(id);
        }

        public async Task UpdateEntretien(int id, Entretien Entretien)
        {
            this._context.Entry(Entretien).State = EntityState.Modified;
            await this._context.SaveChangesAsync();
        }
       public async Task<dynamic> GetEntretienByCandidat(int candidatid)
        {
            var Entretien = await this._context.Entretiens.Where(e=>e.CandidatId==candidatid).ToListAsync();
            if (Entretien is null) return null;
             Entretien.Select(async e => e.Templates = _context.Templates.Where(x => x.EntretienId == e.Id).ToList()).ToList();
             Entretien.ForEach(async e =>
            {
                e.Templates.Select(async e => e.Note = await _context.Notes.FindAsync(e.NotesId)).ToList();
            });


            
            return Entretien;

        }
    }
}

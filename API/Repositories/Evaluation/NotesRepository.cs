

namespace API_MySIRH.Repositories
{
    using API_MySIRH.Data;
    using API_MySIRH.DTOs;
    using API_MySIRH.Entities;
    using API_MySIRH.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    public class NoteRepository : INotesRepository
    {
        private readonly DataContext _context;


        public NoteRepository(DataContext context)
        {
            this._context = context;
        }

        public async Task<Notes> AddNote(Notes Note)
        {
            await this._context.Notes.AddAsync(Note);
            await this._context.SaveChangesAsync();
            return Note;
        }

        public async Task<bool> NoteExists(int id)
        {
            return await this._context.Notes.AnyAsync(Note => Note.Id == id);
        }

        public async Task DeleteNote(int id)
        {
            var NoteToDelete = await this._context.Notes.FindAsync(id);
            if (NoteToDelete is not null)
                this._context.Notes.Remove(NoteToDelete);
            await this._context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Notes>> GetNotes()
        {
            return await this._context.Notes.ToListAsync();
        }

        public async Task<Notes> GetNote(int id)
        {
            return await _context.Notes.FindAsync(id);
        }

        public async Task UpdateNote(int id, Notes Note)
        {
            this._context.Entry(Note).State = EntityState.Modified;
            await this._context.SaveChangesAsync();
        }


        public async Task<Notes> findNoteByTemplate(int Templateid)
        {
            //  return await _context.Notes.Where(e=>e.TemplateId.Equals(Templateid)).FirstOrDefaultAsync();
            return null;
        }

    }
}

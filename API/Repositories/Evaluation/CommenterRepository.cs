

namespace API_MySIRH.Repositories
{
    using API_MySIRH.Data;
    using API_MySIRH.DTOs;
    using API_MySIRH.Entities;
    using API_MySIRH.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    public class CommenterRepository : ICommenterRepository
    {
        private readonly DataContext _context;


        public CommenterRepository(DataContext context)
        {
            this._context = context;
        }

        public async Task<Notes> AddCommenter(Notes Commenter)
        {
            await this._context.Notes.AddAsync(Commenter);
            await this._context.SaveChangesAsync();
            return Commenter;
        }

        public async Task<bool> CommenterExists(int id)
        {
            return await this._context.Notes.AnyAsync(Commenter => Commenter.Id == id);
        }

        public async Task DeleteCommenter(int id)
        {
            var CommenterToDelete = await this._context.Notes.FindAsync(id);
            if (CommenterToDelete is not null)
                this._context.Notes.Remove(CommenterToDelete);
            await this._context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Notes>> GetNotes()
        {
            return await this._context.Notes.ToListAsync();
        }

        public async Task<Notes> GetCommenter(int id)
        {
            return await _context.Notes.FindAsync(id);
        }

        public async Task UpdateCommenter(int id, Notes Commenter)
        {
            this._context.Entry(Commenter).State = EntityState.Modified;
            await this._context.SaveChangesAsync();
        }

    }
}



namespace API_MySIRH.Interfaces
{


    using API_MySIRH.DTOs;
    using API_MySIRH.Entities;
    using Microsoft.AspNetCore.Mvc;

    public interface INotesRepository
    {
        Task<IEnumerable<Notes>> GetNotes();
        Task<Notes> GetNote(int id);
        Task UpdateNote(int id, Notes Note);
        Task<Notes> AddNote(Notes Note);
        Task DeleteNote(int id);
        Task<bool> NoteExists(int id);

    }
}

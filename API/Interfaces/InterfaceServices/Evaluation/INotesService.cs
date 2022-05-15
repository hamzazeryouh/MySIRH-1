

namespace API_MySIRH.Interfaces
{


    using API_MySIRH.DTOs;
    using Microsoft.AspNetCore.Mvc;

    public interface INoteservice
    {
        Task<IEnumerable<NoteDTO>> GetNotes();
        Task<NoteDTO> GetNote(int id);
        Task UpdateNote(int id, NoteDTO Note);
        Task<NoteDTO> AddNote(NoteDTO Note);
        Task DeleteNote(int id);
        Task<NoteDTO> findNoteByTemplate(int Templateid);

    }
}

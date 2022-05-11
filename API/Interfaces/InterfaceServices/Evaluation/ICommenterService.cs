

namespace API_MySIRH.Interfaces
{


    using API_MySIRH.DTOs;
    using Microsoft.AspNetCore.Mvc;

    public interface INoteservice
    {
        Task<IEnumerable<NoteDTO>> GetNotes();
        Task<NoteDTO> GetCommenter(int id);
        Task UpdateCommenter(int id, NoteDTO Commenter);
        Task<NoteDTO> AddCommenter(NoteDTO Commenter);
        Task DeleteCommenter(int id);

    }
}

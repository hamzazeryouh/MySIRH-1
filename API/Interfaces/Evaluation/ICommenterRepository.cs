

namespace API_MySIRH.Interfaces
{


    using API_MySIRH.DTOs;
    using API_MySIRH.Entities;
    using Microsoft.AspNetCore.Mvc;

    public interface ICommenterRepository
    {
        Task<IEnumerable<Notes>> GetNotes();
        Task<Notes> GetCommenter(int id);
        Task UpdateCommenter(int id, Notes Commenter);
        Task<Notes> AddCommenter(Notes Commenter);
        Task DeleteCommenter(int id);
        Task<bool> CommenterExists(int id);

    }
}



namespace API_MySIRH.Interfaces
{


    using API_MySIRH.DTOs;
    using API_MySIRH.Entities;
    using Microsoft.AspNetCore.Mvc;

    public interface ICommenterRepository
    {
        Task<IEnumerable<Commenter>> GetCommenters();
        Task<Commenter> GetCommenter(int id);
        Task UpdateCommenter(int id, Commenter Commenter);
        Task<Commenter> AddCommenter(Commenter Commenter);
        Task DeleteCommenter(int id);
        Task<bool> CommenterExists(int id);

    }
}

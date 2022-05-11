

namespace API_MySIRH.Interfaces
{


    using API_MySIRH.DTOs;
    using Microsoft.AspNetCore.Mvc;

    public interface ICommenterService
    {
        Task<IEnumerable<CommenterDTO>> GetCommenters();
        Task<CommenterDTO> GetCommenter(int id);
        Task UpdateCommenter(int id, CommenterDTO Commenter);
        Task<CommenterDTO> AddCommenter(CommenterDTO Commenter);
        Task DeleteCommenter(int id);

    }
}

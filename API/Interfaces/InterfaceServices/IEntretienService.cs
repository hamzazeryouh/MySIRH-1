using API_MySIRH.DTOs;

namespace API_MySIRH.Interfaces.InterfaceServices
{
    public interface IEntretienService
    {
        Task<IEnumerable<EntretienDTO>> GetEntretiens();
        Task<EntretienDTO> GetEntretien(int id);
        Task UpdateEntretien(int id, EntretienDTO Entretien);
        Task<EntretienDTO> AddEntretien(EntretienDTO Entretien);
        Task DeleteEntretien(int id);

        Task<dynamic> GetEntretienByCandidat(int candidatid);
    }
}

using API_MySIRH.Entities;

namespace API_MySIRH.Interfaces
{
    public interface IEntretienRepository
    {
        Task<IEnumerable<Entretien>> GetEntretiens();
        Task<Entretien> GetEntretien(int id);
        Task UpdateEntretien(int id, Entretien Entretien);
        Task<Entretien> AddEntretien(Entretien Entretien);
        Task DeleteEntretien(int id);
    }
}

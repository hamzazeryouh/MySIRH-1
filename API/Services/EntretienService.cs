using API_MySIRH.DTOs;
using API_MySIRH.Interfaces;
using API_MySIRH.Interfaces.InterfaceServices;
using AutoMapper;
using API_MySIRH.Entities;

namespace API_MySIRH.Services
{
    public class EntretienService: IEntretienService
    {
        private readonly IEntretienRepository _EntretienRepository;
        private readonly IMapper _mapper;

        public EntretienService(IEntretienRepository EntretienRepository, IMapper mapper)
        {
            this._EntretienRepository = EntretienRepository;
            this._mapper = mapper;
        }

        public async Task<EntretienDTO> AddEntretien(EntretienDTO Entretien)
        {
            var returnedEntretien = await this._EntretienRepository.AddEntretien(this._mapper.Map<Entretien>(Entretien));
            return this._mapper.Map<EntretienDTO>(returnedEntretien);
        }

        public async Task DeleteEntretien(int id)
        {
            await this._EntretienRepository.DeleteEntretien(id);
        }

        public async Task<EntretienDTO> GetEntretien(int id)
        {
            return this._mapper.Map<EntretienDTO>(await this._EntretienRepository.GetEntretien(id));
        }

        public async Task<IEnumerable<EntretienDTO>> GetEntretiens()
        {
            //var query = this._EntretienRepository.GetEntretiens().ProjectTo<EntretienDTO>(_mapper.ConfigurationProvider).AsNoTracking();
            ////var mapping = this._mapper.Map<PagedList<Entretien>, PagedList<EntretienDTO>>(collabs);
            //return await PagedList<EntretienDTO>.CreateAsync(query, filterParams.pageNumber, filterParams.pageSize);

            var result = await _EntretienRepository.GetEntretiens();
            return _mapper.Map<IEnumerable<Entretien>, IEnumerable<EntretienDTO>>(result);
        }

        public async Task UpdateEntretien(int id, EntretienDTO Entretien)
        {
            await this._EntretienRepository.UpdateEntretien(id, this._mapper.Map<Entretien>(Entretien));
        }
    }
}

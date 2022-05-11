

namespace API_MySIRH.Services
{


    using API_MySIRH.DTOs;
    using API_MySIRH.Entities;
    using API_MySIRH.Interfaces;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;

    public class Noteservice : INoteservice
    {
        private readonly ICommenterRepository _CommenterRepository;
        private readonly IMapper _mapper;

        public Noteservice(ICommenterRepository CommenterRepository, IMapper mapper)
        {
            this._CommenterRepository = CommenterRepository;
            this._mapper = mapper;
        }

        public async Task<NoteDTO> AddCommenter(NoteDTO Commenter)
        {
            var returnedCommenter = await this._CommenterRepository.AddCommenter(this._mapper.Map<Notes>(Commenter));
            return this._mapper.Map<NoteDTO>(returnedCommenter);
        }

        public async Task DeleteCommenter(int id)
        {
            await this._CommenterRepository.DeleteCommenter(id);
        }

        public async Task<NoteDTO> GetCommenter(int id)
        {
            return this._mapper.Map<NoteDTO>(await this._CommenterRepository.GetCommenter(id));
        }

        public async Task<IEnumerable<NoteDTO>> GetNotes()
        {
            //var query = this._CommenterRepository.GetNotes().ProjectTo<CommenterDTO>(_mapper.ConfigurationProvider).AsNoTracking();
            ////var mapping = this._mapper.Map<PagedList<Commenter>, PagedList<CommenterDTO>>(collabs);
            //return await PagedList<CommenterDTO>.CreateAsync(query, filterParams.pageNumber, filterParams.pageSize);

            var result = await _CommenterRepository.GetNotes();
            return _mapper.Map<IEnumerable<Notes>, IEnumerable<NoteDTO>>(result);
        }

        public async Task UpdateCommenter(int id, NoteDTO Commenter)
        {
            await this._CommenterRepository.UpdateCommenter(id, this._mapper.Map<Notes>(Commenter));
        }

    }
}

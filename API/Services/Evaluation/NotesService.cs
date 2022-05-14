

namespace API_MySIRH.Services
{


    using API_MySIRH.DTOs;
    using API_MySIRH.Entities;
    using API_MySIRH.Interfaces;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;

    public class Noteservice : INoteservice
    {
        private readonly INotesRepository _NoteRepository;
        private readonly IMapper _mapper;

        public Noteservice(INotesRepository NoteRepository, IMapper mapper)
        {
            this._NoteRepository = NoteRepository;
            this._mapper = mapper;
        }

        public async Task<NoteDTO> AddNote(NoteDTO Note)
        {
            var returnedNote = await this._NoteRepository.AddNote(this._mapper.Map<Notes>(Note));
            return this._mapper.Map<NoteDTO>(returnedNote);
        }

        public async Task DeleteNote(int id)
        {
            await this._NoteRepository.DeleteNote(id);
        }

        public async Task<NoteDTO> GetNote(int id)
        {
            return this._mapper.Map<NoteDTO>(await this._NoteRepository.GetNote(id));
        }

        public async Task<IEnumerable<NoteDTO>> GetNotes()
        {
            //var query = this._NoteRepository.GetNotes().ProjectTo<NoteDTO>(_mapper.ConfigurationProvider).AsNoTracking();
            ////var mapping = this._mapper.Map<PagedList<Note>, PagedList<NoteDTO>>(collabs);
            //return await PagedList<NoteDTO>.CreateAsync(query, filterParams.pageNumber, filterParams.pageSize);

            var result = await _NoteRepository.GetNotes();
            return _mapper.Map<IEnumerable<Notes>, IEnumerable<NoteDTO>>(result);
        }

        public async Task UpdateNote(int id, NoteDTO Note)
        {
            await this._NoteRepository.UpdateNote(id, this._mapper.Map<Notes>(Note));
        }


        public async Task<NoteDTO> findNoteByTemplate(int Templateid)
        {
          return  this._mapper.Map<NoteDTO>(await this._NoteRepository.findNoteByTemplate(Templateid));
        }


    }
}

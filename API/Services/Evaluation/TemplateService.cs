

namespace API_MySIRH.Services
{


    using API_MySIRH.DTOs;
    using API_MySIRH.Entities;
    using API_MySIRH.Interfaces;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;

    public class TemplateService: ITemplateService
    {

        private readonly ITemplateRepository _TemplateRepository;
        private readonly INotesRepository _NotesRepository;
        private readonly IMapper _mapper;

        public TemplateService(ITemplateRepository TemplateRepository, IMapper mapper, INotesRepository NotesRepository)
        {
            this._TemplateRepository = TemplateRepository;
            this._mapper = mapper;
            this._NotesRepository = NotesRepository;
        }

        public async Task<TemplateDTO> AddTemplate(TemplateDTO Template)
        {
            var returnedTemplate = await this._TemplateRepository.AddTemplate(this._mapper.Map<Template>(Template));
            return this._mapper.Map<TemplateDTO>(returnedTemplate);
        }

        public async Task DeleteTemplate(int id)
        {
            await this._TemplateRepository.DeleteTemplate(id);
        }

        public async Task<TemplateDTO> GetTemplate(int id)
        {
            return this._mapper.Map<TemplateDTO>(await this._TemplateRepository.GetTemplate(id));
        }

        public async Task<IEnumerable<dynamic>> GetTemplates()
        {
            //var query = this._TemplateRepository.GetTemplates().ProjectTo<TemplateDTO>(_mapper.ConfigurationProvider).AsNoTracking();
            ////var mapping = this._mapper.Map<PagedList<Template>, PagedList<TemplateDTO>>(collabs);
            //return await PagedList<TemplateDTO>.CreateAsync(query, filterParams.pageNumber, filterParams.pageSize);
           
            var result = await _TemplateRepository.GetTemplates();
            foreach (var template in result)
            {
                if (template.NotesId is null)
                {
                    template.Note = null;
                }
                else
                {
                    template.Note = await _NotesRepository.GetNote(template.NotesId.Value);
                }

            }

            // _mapper.Map<IEnumerable<Template>, IEnumerable<TemplateDTO>>(result);

            // var note = await _NotesRepository.GetNote()
            return result;
        }

        public async Task UpdateTemplate(int id, TemplateDTO Template)
        {
            await this._TemplateRepository.UpdateTemplate(id, this._mapper.Map<Template>(Template));
        }


        public async Task UpdateTemplateNote(int id, int Template)
        {
            var data =await _TemplateRepository.GetTemplate(id);
            data.NoteValue=Template;
             await this._TemplateRepository.UpdateTemplate(id, data);
        }

        public async Task UpdateTemplatecommenter(int id, string commenter)
        {
            var data = await _TemplateRepository.GetTemplate(id);
            data.Commenter = commenter;
            await this._TemplateRepository.UpdateTemplate(id, data);
        }
    }
}

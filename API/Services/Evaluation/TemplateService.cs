

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
        private readonly IMapper _mapper;

        public TemplateService(ITemplateRepository TemplateRepository, IMapper mapper)
        {
            this._TemplateRepository = TemplateRepository;
            this._mapper = mapper;
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

        public async Task<IEnumerable<TemplateDTO>> GetTemplates()
        {
            //var query = this._TemplateRepository.GetTemplates().ProjectTo<TemplateDTO>(_mapper.ConfigurationProvider).AsNoTracking();
            ////var mapping = this._mapper.Map<PagedList<Template>, PagedList<TemplateDTO>>(collabs);
            //return await PagedList<TemplateDTO>.CreateAsync(query, filterParams.pageNumber, filterParams.pageSize);

            var result = await _TemplateRepository.GetTemplates();
            return _mapper.Map<IEnumerable<Template>, IEnumerable<TemplateDTO>>(result);
        }

        public async Task UpdateTemplate(int id, TemplateDTO Template)
        {
            await this._TemplateRepository.UpdateTemplate(id, this._mapper.Map<Template>(Template));
        }


        public async Task UpdateTemplateNote(int id, TemplateNoteDTO Template)
        {
            await this._TemplateRepository.UpdateTemplate(id, this._mapper.Map<Template>(Template));
        }
    }
}

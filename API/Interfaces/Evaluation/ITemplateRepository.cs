

namespace API_MySIRH.Interfaces
{


    using API_MySIRH.DTOs;
    using API_MySIRH.Entities;
    using Microsoft.AspNetCore.Mvc;

    public interface ITemplateRepository
    {

        Task<IEnumerable<Template>> GetTemplates();
        Task<Template> GetTemplate(int id);
        Task UpdateTemplate(int id, Template Template);
        Task<Template> AddTemplate(Template Template);
        Task DeleteTemplate(int id);
        Task<bool> TemplateExists(int id);
        Task<IEnumerable<Template>> GetTemplatesByEvaluation(int id);
    }
}

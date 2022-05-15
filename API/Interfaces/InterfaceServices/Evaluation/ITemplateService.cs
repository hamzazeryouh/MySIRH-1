

namespace API_MySIRH.Interfaces
{


    using API_MySIRH.DTOs;
    using Microsoft.AspNetCore.Mvc;

    public interface ITemplateService
    {
        Task<IEnumerable<dynamic>> GetTemplates();
        Task<TemplateDTO> GetTemplate(int id);
        Task UpdateTemplate(int id, TemplateDTO Template);
        Task<TemplateDTO> AddTemplate(TemplateDTO Template);
        Task DeleteTemplate(int id);

        Task UpdateTemplateNote(int id, int Template);

        Task UpdateTemplatecommenter(int id, string commenter);

    }
}



namespace API_MySIRH.Repositories
{
    using API_MySIRH.Data;
    using API_MySIRH.DTOs;
    using API_MySIRH.Entities;
    using API_MySIRH.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    public class TemplateRepository : ITemplateRepository
    {
        private readonly DataContext _context;


        public TemplateRepository(DataContext context)
        {
            this._context = context;
        }

        public async Task<Template> AddTemplate(Template Template)
        {
            await this._context.Templates.AddAsync(Template);
            await this._context.SaveChangesAsync();
            return Template;
        }

        public async Task<bool> TemplateExists(int id)
        {
            return await this._context.Templates.AnyAsync(Template => Template.Id == id);
        }

        public async Task DeleteTemplate(int id)
        {
            var TemplateToDelete = await this._context.Templates.FindAsync(id);
            if (TemplateToDelete is not null)
                this._context.Templates.Remove(TemplateToDelete);
            await this._context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Template>> GetTemplates()
        {
            return await this._context.Templates.ToListAsync();
        }

        public async Task<Template> GetTemplate(int id)
        {
            return await _context.Templates.FindAsync(id);
        }

        public async Task UpdateTemplate(int id, Template Template)
        {
            this._context.Entry(Template).State = EntityState.Modified;
            await this._context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Template>> GetTemplatesByEvaluation(int id)
        {
            return null; /* await _context.Templates.Where(t => t.EvaluationId == id).ToListAsync();*/
        }
    }
}

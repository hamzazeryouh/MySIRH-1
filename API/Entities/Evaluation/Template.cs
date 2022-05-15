using API_MySIRH.Entities.Evaluation;

namespace API_MySIRH.Entities
{
    public class Template:EntityBase
    {
        public string? Technologie { get; set; }
        public string? Them { get; set; }
        public string? Title { get; set; }
        public int? EntretienId { get; set; }
        public Entretien? Entretien { get; set; }

        public int? NotesId { get; set; }
        public Notes? Note { get; set; }
    }
}

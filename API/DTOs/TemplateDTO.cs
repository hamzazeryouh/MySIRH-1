namespace API_MySIRH.DTOs
{
    public class TemplateDTO : DtoBase
    {
        public string? Technologie { get; set; }
        public string? Them { get; set; }
        public string? Title { get; set; }
        public int? EntretienId { get; set; }
        public int? NotesId { get; set; }

        public NoteDTO? Notes { get; set; }
    }
}

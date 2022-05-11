namespace API_MySIRH.DTOs
{
    public class NoteDTO : DtoBase
    {
        public string? Commente { get; set; }
        public string? Note { get; set; }
        public int TemplateId { get; set; }
    }
}

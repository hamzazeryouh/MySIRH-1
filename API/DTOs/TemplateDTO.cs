namespace API_MySIRH.DTOs
{
    public class TemplateDTO : DtoBase
    {
        public string? Technologie { get; set; }
        public string? Them { get; set; }
        public string? Title { get; set; }
        public decimal? Note { get; set; }
        public int EvaluationId { get; set; }
        public int? CommenterId { get; set; }
    }
}

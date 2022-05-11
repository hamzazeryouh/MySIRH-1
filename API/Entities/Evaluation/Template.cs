namespace API_MySIRH.Entities
{
    public class Template:EntityBase
    {
        public string? Technologie { get; set; }
        public string? Them { get; set; }
        public string? Title { get; set; }

        public decimal? Note { get; set; }
        public int? EvaluationId { get; set; }
        public Evaluation.Evaluation? Candidat { get; set; }

        public int? CommenterId { get; set; } = null;
        public Commenter? Commenter { get; set; } = null;


    }
}

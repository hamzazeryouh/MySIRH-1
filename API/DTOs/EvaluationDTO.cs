using API_MySIRH.Entities;

namespace API_MySIRH.DTOs
{
    public class EvaluationDTO : DtoBase
    {
        public string? Evaluateur { get; set; }
        public DateTime? DateEntretien { get; set; }
        public int CandidatId { get; set; }
        public int CommenterId { get; set; }

        public string? Commente { get; set; }

    }
}

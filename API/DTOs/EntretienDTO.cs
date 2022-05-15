namespace API_MySIRH.DTOs
{
    public class EntretienDTO: DtoBase
    {
        public string? Evaluateur { get; set; }
        public DateTime? DateEntretien { get; set; }
        public int CandidatId { get; set; }
        public string? Commente { get; set; }
    }
}

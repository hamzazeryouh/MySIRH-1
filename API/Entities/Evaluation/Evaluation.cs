namespace API_MySIRH.Entities.Evaluation
{
    public  class Evaluation:EntityBase
    {
        public Evaluation()
        {
            Templates = new HashSet<Template>();
        }
       public string?  Evaluateur { get; set; }  
       public DateTime? DateEntretien { get; set; }
        public int CandidatId { get; set; }
        public Candidat Candidat { get; set; }


        public ICollection<Template?> Templates { get; set; } 

        public string? Commente { get; set; }


    }
}

namespace APIVinotrip.Models.DTO
{
    public class AvisDTO
    {
        public int IdAvis { get; set; }
        public int IdSejour { get; set; }
        public int IdClient { get; set; }
        public DateTime DateAvis { get; set; }
        public string TitreAvis { get; set; }
        public string DescriptionAvis { get; set; }
        public int NoteAvis { get; set; }
        public string PhotoAvis { get; set; }

        
    }

}
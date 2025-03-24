namespace APIVinotrip.Models.DTO
{
    public class SejourDTO
    {
        public int IdSejour { get; set; }
        public string TitreSejour { get; set; }
        public string PhotoSejour { get; set; }
        public string DescriptionSejour { get; set; }
        public decimal PrixSejour { get; set; }
        public decimal? NouveauPrixSejour { get; set; }
        public bool Publie { get; set; }

        public int IdDuree { get; set; }
        public int? IdCategorieVignoble { get; set; }
        public int IdCategorieSejour { get; set; }
        public int? IdLocalite { get; set; }
        public int IdTheme { get; set; }
        public int IdCategorieParticipant { get; set; }

        public int NombreAvis { get; set; }
        public double NoteMoyenne { get; set; }


        public List<AvisDTO> Avis { get; set; } = new List<AvisDTO>();
    }
}

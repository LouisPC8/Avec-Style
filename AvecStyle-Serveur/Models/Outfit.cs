namespace AvecStyle_Serveur.Models
{
    public class Outfit
    {
        public ArticleDTO Top { get; set; } = null!;
        public ArticleDTO Bottom { get; set; } = null!;
        public ArticleDTO Shoes { get; set; } = null!;
        public ArticleDTO Accessory { get; set; } = null!;
    }
}

namespace AvecStyle_Serveur.Models
{
    public class ArticleDTO
    {
        public int Id { get; set; }
        public string ShopURL { get; set; } = null!;
        public string ImageURL { get; set; }

        public ArticleDTO(Article a)
        {
            Id = a.Id;
            ShopURL = a.ShopURL;
            ImageURL = a.ImageURL;
        }
    }
}

using AvecStyle_Serveur.Models.Enums;
using System.Text.Json.Serialization;

namespace AvecStyle_Serveur.Models
{
    public class Article
    {
        public int Id { get; set; }
        public bool Gender { get; set; }
        public string ShopURL { get; set; } = null!;
        public string Style { get; set; } = null!;
        public Category Category { get; set; }
        public Shape Shape { get; set; }
        public string ImageURL { get; set; } = null!;

        //[JsonIgnore]
        //public Image? Image { get; set; }
    }
}

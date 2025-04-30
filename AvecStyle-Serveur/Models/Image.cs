using System.Text.Json.Serialization;

namespace AvecStyle_Serveur.Models
{
    public class Image
    {
        public int Id { get; set; }

        // Deux seules propriétés nécessaires pour faire référence à une image
        public string FileName { get; set; } = null!;
        public string MimeType { get; set; } = null!;

        //public int ArticleId { get; set; }
        //[JsonIgnore]
        //public Article Article { get; set; } = null!; // Navigation property pour l'article associé
    }
}

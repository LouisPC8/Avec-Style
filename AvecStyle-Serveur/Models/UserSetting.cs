using AvecStyle_Serveur.Models.Enums;

namespace AvecStyle_Serveur.Models
{
    public class UserSetting
    {
        public bool Gender {  get; set; }
        public string Style { get; set; } = null!;
        public Shape Shape { get; set; }
    }
}

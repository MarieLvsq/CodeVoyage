using System;
namespace CodeVoyage.Models
{
    public class Partenaire
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public Service ServiceDeBase { get; set; }
        public Service ServiceExtra { get; set; }
        public string Localisation { get; set; }
        public string email { get; set; }
        public string NumSiret{ get; set; }
        public string NumSiren { get; set; }

    }
}

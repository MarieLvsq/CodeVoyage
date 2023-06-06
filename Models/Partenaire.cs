using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CodeVoyage.Models
{
    public class Partenaire
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Le nom doit être rempli.")]
        public string Nom { get; set; }
        public string Localisation { get; set; }
        public string email { get; set; }
        public string MotDePasse { get; set; }

        public Role Role { get; set; }
        [Display(Name = "Numéro de siret")]
        [Required(ErrorMessage = "le numéro de Siret contient 10 chiffres.")]
        public string NumSiret{ get; set; }
        public TypeService TypeService { get; set; }
       

    }
}

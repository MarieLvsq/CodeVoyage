using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CodeVoyage.Models
{
    public class Partenaire
    {
        public int Id { get; set; }

        
        public string Nom { get; set; }

        
        public string Localisation { get; set; }


        
        [Display(Name = "E-mail")]
        public string email { get; set; }



        
        [Display(Name = "Mot de passe")]
        public string MotDePasse { get; set; }

        
        public Role Role { get; set; }

        
        [Display(Name = "Numéro SIRET")]
        public string NumSiret{ get; set; }


        
        [Display(Name = "Type de Service")]
        public TypeService TypeService { get; set; }
       

    }
}

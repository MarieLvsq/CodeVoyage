using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CodeVoyage.Models
{
	public class Admin
	{
        public int Id { get; set; }
 
        public string Nom { get; set; }

        public string Prenom { get; set; }

        [Required(ErrorMessage = "Cette section doit être remplie.")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Cette section doit être remplie.")]
        [Display(Name = "Mot de passe")]
        public string MotDePasse { get; set; }
       
    }
}


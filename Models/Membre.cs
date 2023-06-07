using System;
using System.ComponentModel.DataAnnotations;

namespace CodeVoyage.Models
{
    public class Membre
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Cette section doit être remplie.")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Cette section doit être remplie.")]
        [Display(Name = "Prénom")]
        public string Prenom { get; set; }

        [Required(ErrorMessage = "Cette section doit être remplie.")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Cette section doit être remplie.")]
        [Display(Name = "Mot de passe")]
        public string MotDePasse { get; set; }

        [Required(ErrorMessage = "Cette section doit être remplie.")]
        [Display(Name = "Ville")]
        public string Localisation { get; set; }

        [Required(ErrorMessage = "Cette section doit être remplie.")]
        [Display(Name = "Âge")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Cette section doit être remplie.")]
        [Display(Name = "Je suis un(e)")]
        public Role User { get; set; }

        public string MembreDescription
        {
            get
            {
                return string.Format("{0} {1}", Nom+ "-", Prenom+ "-",Localisation);
            }
        }
    }


}


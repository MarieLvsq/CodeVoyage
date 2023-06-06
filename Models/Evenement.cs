using System;
using System.ComponentModel.DataAnnotations;

namespace CodeVoyage.Models
{
    public class Evenement
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom doit être rempli.")]
        public string Nom { get; set; }

        [Display(Name = "Date de début")]
        public DateTime DateDeb { get; set; }
        
        [Display(Name = "Date de fin")]
        public DateTime DateFin { get; set; }

        [Required(ErrorMessage = "Le lieu doit être renseigné.")]
        public string Localisation{ get; set; }

        [Required(ErrorMessage = "Le type d'évènement doit être choisi.")]
        public TypeEvenement TypeEvenement { get; set; }

        public string EvenementDescription
        {
            get
            {
                return string.Format("{0} {1} ", Nom+",", Localisation);
            }
        }
    }


}


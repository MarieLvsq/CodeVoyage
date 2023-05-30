using System;
using System.ComponentModel.DataAnnotations;

namespace CodeVoyage.Models
{
	public class Evenement
	{
        public int Id { get; set; }
        [Required(ErrorMessage = "Le nom doit être rempli.")]
        public string Nom{ get; set; }
        //[Required(ErrorMessage = "La date doit être écrite.")]
        public DateTime Date { get; set; }
        //[Required(ErrorMessage = "Le lieu doit être renseigné.")]
        public string Localisation{ get; set; }
        //[Required(ErrorMessage = "Le type d'évènement doit être choisi.")]
        public TypeEvenement TypeEvenement { get; set; }
    }


}


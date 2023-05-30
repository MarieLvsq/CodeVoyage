using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CodeVoyage.Models
{
    public class Service
	{
        public int Id { get; set; }
        [Display(Name = "Nom du Service")]
        [Required(ErrorMessage = "Le nom du service doit être rempli.")]
        public string nomService { get; set; }

        [Display(Name = "Type de Service")]
        public TypeService TypeService { get; set; }
        [Display(Name = "Capacité")]

        public int Capacite { get; set; }
        [Display(Name = "Date de début")]
        public DateTime DateDeb { get; set; }
        [Display(Name = "Date de fin")]
        public DateTime DateFin { get; set; }
        [Display(Name = "Prix en euros")]
        public double Prix { get; set; }

    }
}


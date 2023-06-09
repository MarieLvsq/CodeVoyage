using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CodeVoyage.Models
{
	public class Itineraire
	{
        public int Id { get; set; }

        [Required(ErrorMessage = "Cette section doit être remplie.")]
        [Display(Name = "Lieu de départ")]
        public string LieuDepart { get; set; }

        [Required(ErrorMessage = "Cette section doit être remplie.")]
        public string Destination { get; set; }

        [Required(ErrorMessage = "Cette section doit être remplie.")]
        [Display(Name = "Prix")]
        public double Prix { get; set; }

        [Required(ErrorMessage = "Cette section doit être remplie.")]
        public MoyenDeTransport Transport { get; set; }

        [Required(ErrorMessage = "Cette section doit être remplie.")]
        [Display(Name = "Nombre de voyageurs prévus")]
        public int NombreVoyageur { get; set; }

        [Required(ErrorMessage = "Cette section doit être remplie.")]
        [Display(Name = "Date de départ")]
        public DateTime DateDepart { get; set; }


        [Required(ErrorMessage = "Cette section doit être remplie.")]
        [Display(Name = "Date de retour")]
        public DateTime DateRetour { get; set; }

        public string ItineraireDescription
        {
            get
            {
                return string.Format("{0} {1}", LieuDepart+"-", Destination);
            }
        }

        public string ItineraireDescription2
        {
            get
            {
                return string.Format("{0} {1} {2}", LieuDepart + "-", Destination+ "-",Transport);
            }
        }



       

    }
}


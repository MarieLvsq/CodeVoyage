using System;
namespace CodeVoyage.Models
{
	public class Itineraire
	{
        public int Id { get; set; }
        public string LieuDepart { get; set; }
        public string Destination { get; set; }
        public double Prix { get; set; }
        public MoyenDeTransport Transport { get; set; }
        public int NombreVoyageur { get; set; }
        public DateTime DateDepart { get; set; }
        public DateTime DateArrivee { get; set; }

        public string ItineraireDescription
        {
            get
            {
                return string.Format("{0} {1} {2} ", LieuDepart+"-", Destination+ "-", Transport);
            }
        }

        public string ItineraireDescription2
        {
            get
            {
                return string.Format("{0} {1} {2} {3} {4}", "Lieu de départ:"+ LieuDepart + "-", "Destination :" +Destination + "-", "Départ :"+DateDepart + "-", "Retour :"+ DateArrivee + "-", "Moyen de Transport:" +Transport);
            }
        }



    }
}


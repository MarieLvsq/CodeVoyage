using System;
namespace CodeVoyage.Models
{
	public class OffreVoyage
	{
		public int Id { get; set; }
        public int ItineraireId { get; set; }
        public virtual Itineraire Itineraire { get; set; }
        public int EventId { get; set; }
        public virtual Evenement Event { get; set; }
        public int ServiceId { get; set; }
        public virtual Service Service { get; set; }
        public int ServiceExId { get; set; }
        public virtual Service ServiceEx { get; set; }
        public int Remise { get; set; }
        public double prixTotal { get; set; }
        public double prixAffiche { get; set; }

        public string OffreVoyageDescription
        {
            get
            {
                return string.Format("{0} {1} {2} {3}", Itineraire.LieuDepart+ "-", Itineraire.Destination+ "-",Event.Nom+ "-",prixTotal);
            }
        }
    }

}


using System;
namespace CodeVoyage.Models
{
	public class OffreVoyage
	{
		public int Id { get; set; }
        public Itineraire Itineraire { get; set; }
        public Evenement Event { get; set; }
        public Service Service { get; set; }
        public Service ServiceEx { get; set; }
        public int Remise { get; set; }
        public double prixTotal { get; set; }
        public double prixAffiche { get; set; }
    }

}


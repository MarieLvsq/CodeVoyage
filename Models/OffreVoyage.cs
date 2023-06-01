using System;
namespace CodeVoyage.Models
{
	public class OffreVoyage
	{
		public int Id { get; set; }
        public virtual Itineraire Itineraire { get; set; }
        public virtual Evenement Event { get; set; }
        public virtual Service Service { get; set; }
        public virtual Service ServiceEx { get; set; }
        public int Remise { get; set; }
        public double prixTotal { get; set; }
        public double prixAffiche { get; set; }
    }

}


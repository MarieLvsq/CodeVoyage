using System;
namespace CodeVoyage.Models
{
	public class ReservationPerso
	{

        public int Id { get; set; }

        public int MembreId { get; set; }
        public virtual Membre Membre { get; set; }


        public int OffreVoyageId { get; set; }
        public virtual OffrePerso Offre { get; set; }
    
	}
}


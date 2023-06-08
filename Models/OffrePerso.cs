using System;
namespace CodeVoyage.Models
{
	public class OffrePerso
	{
		
        public int Id { get; set; }


        public int OffreId { get; set; }
        public virtual OffreVoyage Offre { get; set; }


        public int ServicePersoId { get; set; }
        public virtual Service ServicePerso { get; set; }

    }
}


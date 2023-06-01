using System;
using System.Collections.Generic;

namespace CodeVoyage.Models
{
	public class RechercheMulti
	{
        public int Id { get; set; }
        public virtual Itineraire Itineraire { get; set; }
        public virtual Evenement Event { get; set; }
        public virtual Service Service { get; set; }
        public virtual Service ServiceEx { get; set; }
        public double prixTotal { get; set; }
       
    }
}


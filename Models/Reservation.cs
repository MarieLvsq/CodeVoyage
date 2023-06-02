﻿using System;
namespace CodeVoyage.Models
{
	public class Reservation
	{
        public int Id { get; set; }
        public virtual Membre Membre { get; set; }
        public int MembreId { get; set; }
        public virtual OffreVoyage OffrePayee { get; set; }
        public int OffreVoyageId { get; set; }


    }
}


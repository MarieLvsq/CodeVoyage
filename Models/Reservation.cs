﻿using System;
namespace CodeVoyage.Models
{
	public class Reservation
	{
        public int Id { get; set; }
        public int MembreId  { get; set; }
        public virtual OffreVoyage OffrePayee { get; set; }
    }
}


using System;
namespace CodeVoyage.Models
{
	public class Membre
	{
		public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public Statut Statut { get; set; }
        public string Localisation { get; set; }
        public int Age { get; set; }
        public Role User { get; set; }

        
	}
}


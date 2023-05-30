using System;
using System.Collections.Generic;

namespace CodeVoyage.Models
{
	public interface IDal
	{
        public interface IDal
        {
            void DeleteCreateDatabase();
            // Methodes OffreVoyage

            List<OffreVoyage> ObtientToutesLesOffresDeVoyage();
            int CreerOffresVoyage(Itineraire Itineraire, Evenement Event, Service Service, Service ServiceEx, int Remise, double PrixTotal, double prixAffiche);
            void ModifierOffreVoyage(int id, Itineraire Itineraire, Evenement Event, Service Service, Service ServiceEx, int Remise, double PrixTotal, double prixAffiche);

            //Methodes Evenements
            List<Evenement> ObtientTousLesEvenements();
            
             int CreerEvenement(string Nom, DateTime Date, string Localisation, TypeEvenement TypeEvent);
             void ModifierEvenement(int id, string Nom, DateTime Date, string Localisation, TypeEvenement TypeEvent);
             void SupprimerEvenementint (int id);

            //Methodes Services

            List<Service> ObtientTousLesService();
            int CreerService(string nomService, TypeService TypeService, int Capacite, DateTime Date, double Prix);
            void ModifierService(int Id, string nomService, TypeService TypeService, int Capacite, DateTime Date, double Prix);
            void SupprimerService(int id);
        }
    }
   
    

}


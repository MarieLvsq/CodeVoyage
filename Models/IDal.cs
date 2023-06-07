using System;
using System.Collections.Generic;

namespace CodeVoyage.Models
{
	public interface IDal
	{
        List<OffreVoyage> RechercheMultiCritere(int itineraireId, int eventId, int serviceId, int serviceExId, int Remise, double prixMin, double prixMax);

        public interface IDal
        {
            void DeleteCreateDatabase();
            // Methodes OffreVoyage

            List<OffreVoyage> ObtientToutesLesOffresDeVoyage();
            int CreerOffresVoyage(Itineraire Itineraire, Evenement Event, Service Service, Service ServiceEx, int Remise, double PrixTotal, double prixAffiche);
            void ModifierOffreVoyage(int id, Itineraire Itineraire, Evenement Event, Service Service, Service ServiceEx, int Remise, double PrixTotal, double prixAffiche);
            List<OffreVoyage> RechercheOffre(int itineraireId, int eventId, int serviceId, int serviceExId, int Remise,
            double prixMin, double prixMax);

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



            //Methodes Itineraire
            List<Itineraire> ObtientTousLesItineraires();

            int CreerItineraire(string LieuDepart, String Destination, double Prix, MoyenDeTransport Transport, int NombreVoyageur, DateTime DateDepart, DateTime DateArrivee);
            void ModifierItineraire(int Id, string LieuDepart, String Destination, double Prix, MoyenDeTransport Transport, int NombreVoyageur, DateTime DateDepart, DateTime DateArrivee);
            void SupprimerItineraire(int Id);


            //Methodes Partenaire

            public List<Partenaire> ObtientTousLesPartenaires();

            int InscriptionPartenaire(string Nom, string Localisation, string email, string numSiret, TypeService typeService, Role role);
            void ModifierPartenaire(int Id, string Nom, string Localisation, string email, string numSiret, TypeService typeService, Role role);
            void SupprimerPartenaire(int id);

            //Methodes Membres

            List<Service> ObtientTousLesMembres();
            int InscriptionMembre(string Nom, string Prenon, string Email, Statut Statut, string Localisation, int Age, Role user);
            void ModifierMembre(int Id, string Nom, string Prenon, string Email, Statut Statut, string Localisation, int Age, Role user);
            void SupprimerMembre(int id);


            //Methodes Reservations

            List<Service> ObtientToutesLesReservations();
            int CreerReservation(Membre membre, OffreVoyage offreVoyage);
            void ModifierReservation(int Id, Membre membre, OffreVoyage offreVoyage);
            void SupprimerReservation(int id);

        }
    }
   
    

}


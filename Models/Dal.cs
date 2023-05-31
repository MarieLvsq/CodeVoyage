using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeVoyage.Models
{
    public class Dal : IDal, IDisposable
    {
        private BddContext _bddContext;
        public Dal()
        {
            _bddContext = new BddContext();
        }

        public void DeleteCreateDatabase()
        {
            _bddContext.Database.EnsureDeleted();
            _bddContext.Database.EnsureCreated();
        }

        // Méthodes OffresVoyage

        public List<OffreVoyage> ObtientToutesLesOffresVoyages()
        {
            return _bddContext.OffreVoyages.ToList();
        }

        public int CreerOffreVoyage(Itineraire Itineraire, Evenement Event, Service Service, Service ServiceEx, int Remise, double prixAffiche, double PrixTotal)
        {

            OffreVoyage offre = new OffreVoyage() { Itineraire = Itineraire, Event = Event, Service = Service, ServiceEx = ServiceEx, Remise = Remise, prixAffiche = prixAffiche, prixTotal = PrixTotal };

            _bddContext.OffreVoyages.Add(offre);
            _bddContext.SaveChanges();
            return offre.Id;
        }

        public void ModifierOffreVoyage(int id, Itineraire Itineraire, Evenement Event, Service Service, Service ServiceEx, int Remise, double prixAffiche, double PrixTotal)
        {
            OffreVoyage offre = _bddContext.OffreVoyages.Find(id);

            if (offre != null)
            {
                offre.Itineraire = Itineraire;
                offre.Event = Event;
                offre.Service = Service;
                offre.ServiceEx = ServiceEx;
                offre.Remise = Remise;
                offre.prixAffiche = prixAffiche;
				offre.prixTotal = PrixTotal;
				_bddContext.SaveChanges();
            }

        }
		public void ModifierOffreVoyage(OffreVoyage offreVoyage)
		{


			_bddContext.OffreVoyages.Update(offreVoyage);
			_bddContext.SaveChanges();
		}


		public void SupprimerOffreVoyage(int id) // A tester
		{
			OffreVoyage offreVoyage = _bddContext.OffreVoyages.Find(id);


			if (offreVoyage != null)
			{

				_bddContext.OffreVoyages.Remove(offreVoyage);

				_bddContext.SaveChanges();
			}
		}
		// Fin méthodes Offre de voyage


		// Méthodes Evenements


		public List<Evenement> ObtientTousLesEvenements()
        {
            return _bddContext.Evenements.ToList();
        }

        public int CreerEvenement(string Nom, DateTime Date, string Localisation, TypeEvenement TypeEvent)
        {

            Evenement evenement = new Evenement() { Nom= Nom, DateDeb= Date, DateFin = Date,Localisation = Localisation,TypeEvenement= TypeEvent};

            _bddContext.Evenements.Add(evenement);
            _bddContext.SaveChanges();
            return evenement.Id;
        }

        public void ModifierEvenement(int id, string Nom, DateTime DateDeb , DateTime DateFin  ,string Localisation, TypeEvenement TypeEvent)
        {
           Evenement evenement = _bddContext.Evenements.Find(id);

            if (evenement != null)
            {
                evenement.Nom = Nom;
                evenement.DateDeb = DateDeb;
                evenement.DateFin = DateFin;
                evenement.Localisation = Localisation;
                evenement.TypeEvenement = TypeEvent;
          
                _bddContext.SaveChanges();
            }
      
        }
        public void ModifierEvenement(Evenement evenement)
        {


            _bddContext.Evenements.Update(evenement);
            _bddContext.SaveChanges();

        }
        public void SupprimerEvenement(int id) // A tester
         {
             Evenement evenement = _bddContext.Evenements.Find(id);

            
             if (evenement!=null)
             {

                 _bddContext.Evenements.Remove(evenement);

                 _bddContext.SaveChanges();
             }
         }


        // Méthodes Service


        public List<Service> ObtientTousLesServices()
        {
            return _bddContext.Services.ToList();
        }

        public int CreerService(string nomService, TypeService TypeService, int Capacite, DateTime DateDeb, DateTime DateFin, double Prix)
        {

            Service service = new Service() { nomService = nomService, TypeService = TypeService, Capacite = Capacite, DateDeb = DateDeb, DateFin = DateFin, Prix = Prix };

            _bddContext.Services.Add(service);
            _bddContext.SaveChanges();
            return service.Id;
        }

        public void ModifierService(int Id, string nomService, TypeService TypeService, int Capacite, DateTime DateDeb, DateTime DateFin, double Prix)
        {
            Service service = _bddContext.Services.Find(Id);

            if (service != null)
            {
                service.Id = Id;
                service.nomService = nomService;
                service.TypeService = TypeService;
                service.Capacite = Capacite;
                service.DateDeb = DateDeb;
                service.DateFin = DateFin;
                service.Prix = Prix;

                _bddContext.SaveChanges();
            }

        }
        public void ModifierService(Service service)
        {
                     
            
            _bddContext.Services.Update(service);
            _bddContext.SaveChanges();
        }

        public void SupprimerService(int id) // A tester
        {
            Service service = _bddContext.Services.Find(id);


            if (service != null)
            {

                _bddContext.Services.Remove(service);

                _bddContext.SaveChanges();
            }
        }


        // Méthodes Itineraire


        public List<Itineraire> ObtientTousLesItineraires()
        {
            return _bddContext.Itineraires.ToList();
        }

        public int CreerItineraire(string LieuDepart, String Destination, double Prix, MoyenDeTransport Transport, int NombreVoyageur, DateTime DateDepart, DateTime DateArrivee)
        {

            Itineraire itineraire = new Itineraire() { LieuDepart = LieuDepart, Destination = Destination, Prix = Prix, Transport = Transport, NombreVoyageur = NombreVoyageur, DateDepart = DateDepart, DateArrivee = DateArrivee };

            _bddContext.Itineraires.Add(itineraire);
            _bddContext.SaveChanges();
            return itineraire.Id;
        }

        public void ModifierItineraire(int Id, string LieuDepart, String Destination, double Prix, MoyenDeTransport Transport, int NombreVoyageur, DateTime DateDepart, DateTime DateArrivee)
        {
            Itineraire itineraire = _bddContext.Itineraires.Find(Id);

            if (itineraire != null)
            {
                itineraire.LieuDepart = LieuDepart;
                itineraire.Destination = Destination;
                itineraire.Prix = Prix;
                itineraire.Transport = Transport;
                itineraire.NombreVoyageur = NombreVoyageur;
                itineraire.DateDepart = DateDepart;
                itineraire.DateArrivee = DateArrivee;
                _bddContext.SaveChanges();
            }

        }
        public void ModifierItineraire(Itineraire itineraire)
        {


            _bddContext.Itineraires.Update(itineraire);
            _bddContext.SaveChanges();
        }
        public void SupprimerItineraire(int id) // A tester
        {
            Itineraire itineraire = _bddContext.Itineraires.Find(id);


            if (itineraire != null)
            {

                _bddContext.Itineraires.Remove(itineraire);

                _bddContext.SaveChanges();
            }
        }

        // Methode partenaire
        public List<Partenaire> ObtientTousLesPartenaires()
        {
            return _bddContext.Partenaires.ToList();
        }

        public int InscriptionPartenaire(string Nom, string Localisation, string email, string numSiret, TypeService typeService, Role role)
        {

            Partenaire partenaire = new Partenaire() { Nom = Nom, Localisation = Localisation, email= email, NumSiret = numSiret, TypeService = typeService, Role=role };

            _bddContext.Partenaires.Add(partenaire);
            _bddContext.SaveChanges();
            return partenaire.Id;
        }

        public void ModifierPartenaire(int Id, string Nom, string Localisation, string email, string numSiret, TypeService typeService, Role role)
        {
            Partenaire partenaire = _bddContext.Partenaires.Find(Id);

            if (partenaire != null)
            {
                partenaire.Id = Id;
                partenaire.Nom = Nom;
                partenaire.Localisation = Localisation;
                partenaire.email = email;
                partenaire.NumSiret = numSiret;
                partenaire.TypeService = typeService; 
                partenaire.Role = role;
                

                _bddContext.SaveChanges();
            }

        }
        public void ModifierPartenaire(Partenaire partenaire)
        {


            _bddContext.Partenaires.Update(partenaire);
            _bddContext.SaveChanges();
        }

        public void SupprimerPartenaire(int id) 
        {
            Partenaire partenaire = _bddContext.Partenaires.Find(id);


            if (partenaire != null)
            {

                _bddContext.Partenaires.Remove(partenaire);

                _bddContext.SaveChanges();
            }
        }


        public void Dispose()
        {
            _bddContext.Dispose();
        }

       
    }
}

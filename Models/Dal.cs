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

        public List<OffreVoyage> ObtientToutesLesOffres()
        {
            return _bddContext.OffreVoyages.ToList();
        }

        public int CreerOffresVoyage(Itineraire Itineraire, Evenement Event, Service Service, Service ServiceEx, int Remise, double PrixTotal, double prixAffiche)
        {

            OffreVoyage offre = new OffreVoyage() { Itineraire = Itineraire, Event = Event, Service = Service, ServiceEx = ServiceEx, Remise = Remise, prixTotal = PrixTotal, prixAffiche = prixAffiche };

            _bddContext.OffreVoyages.Add(offre);
            _bddContext.SaveChanges();
            return offre.Id;
        }

        public void ModifierOffreVoyage(int id, Itineraire Itineraire, Evenement Event, Service Service, Service ServiceEx, int Remise, double PrixTotal, double prixAffiche)
        {
            OffreVoyage offre = _bddContext.OffreVoyages.Find(id);

            if (offre != null)
            {
                offre.Itineraire = Itineraire;
                offre.Event = Event;
                offre.Service = Service;
                offre.ServiceEx = ServiceEx;
                offre.Remise = Remise;
                offre.prixTotal = PrixTotal;
                offre.prixAffiche = prixAffiche;
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

            Evenement evenement = new Evenement() { Nom= Nom, Date= Date,Localisation= Localisation,TypeEvenement= TypeEvent};

            _bddContext.Evenements.Add(evenement);
            _bddContext.SaveChanges();
            return evenement.Id;
        }

        public void ModifierEvenement(int id, string Nom, DateTime Date, string Localisation, TypeEvenement TypeEvent)
        {
           Evenement evenement = _bddContext.Evenements.Find(id);

            if (evenement != null)
            {
                evenement.Nom = Nom;
                evenement.Date = Date;
                evenement.Localisation = Localisation;
                evenement.TypeEvenement = TypeEvent;
          
                _bddContext.SaveChanges();
            }
      
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
                service.Capacite = Capacite;                service.DateDeb = DateDeb;                service.DateFin = DateFin;                service.Prix = Prix;

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

        public void Dispose()
        {
            _bddContext.Dispose();
        }
        
    }
}



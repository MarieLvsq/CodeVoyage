using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Cache;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using System.Security.Cryptography;

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

            return _bddContext.OffreVoyages.Include(o => o.Itineraire).Include(o => o.Event).Include(o => o.Service).Include(o => o.ServiceEx).ToList();
        }

        public List<OffrePerso> ObtientToutesLesOffresPerso()
        {

            return _bddContext.OffrePersos
                .Include(op=>op.Offre).ThenInclude(op => op.Itineraire)
                .Include(op => op.Offre).ThenInclude(op => op.Event)
                .Include(op => op.ServicePerso).ToList();
        }

        public int CreerOffreVoyage(int itineraireId, int eventId, int serviceId, int serviceExId, int Remise, double PrixTotal)

            {

            Itineraire itineraire = _bddContext.Itineraires.Find(itineraireId);
            Service service = _bddContext.Services.Find(serviceId);
            Service serviceEx = _bddContext.Services.Find(serviceExId);



            OffreVoyage offre = new OffreVoyage() { ItineraireId = itineraireId, EventId = eventId, ServiceId = serviceId, ServiceExId = serviceExId };
            offre.prixTotal = itineraire.Prix + service.Prix + serviceEx.Prix;


            _bddContext.OffreVoyages.Add(offre);
            _bddContext.SaveChanges();

            return offre.Id;
            }


        public int CreerOffrePerso(int offreId,int serviceId)

        {

            OffrePerso offreP = new OffrePerso() { OffreId = offreId, ServicePersoId = serviceId };

            offreP.Offre = this.ObtientToutesLesOffresVoyages().Where(o => o.Id == offreP.OffreId).FirstOrDefault();
            offreP.ServicePerso = this.ObtientTousLesServices().Where(o => o.Id == offreP.ServicePersoId).FirstOrDefault();

            offreP.prix = offreP.Offre.prixTotal + offreP.ServicePerso.Prix;



            _bddContext.OffrePersos.Add(offreP);

            _bddContext.SaveChanges();
            return offreP.Id;
        }


        public void ModifierOffreVoyage(int id, int ItineraireId, int EventId, int ServiceId, int ServiceExId, int Remise, double PrixTotal)

            {
            OffreVoyage offre = _bddContext.OffreVoyages.Find(id);

            if (offre != null)
                {
                offre.ItineraireId = ItineraireId;
                offre.EventId = EventId;
                offre.ServiceId = ServiceId;
                offre.ServiceExId = ServiceExId;
                offre.Remise = Remise;
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

        public List<OffreVoyage> RechercheOffre(int itineraireId, int eventId, int serviceId, int serviceExId, double prixMax)

        {

            using var dbContext = new Models.BddContext();


            List<OffreVoyage> listeOffreVoyage = _bddContext.OffreVoyages.ToList();
            List<OffreVoyage> listeOffreVoyageMulti = new List<OffreVoyage>();



            foreach (OffreVoyage offre in listeOffreVoyage)
            {

                if ((itineraireId == 0 || offre.ItineraireId == itineraireId)
                  && (eventId == 0 || offre.EventId == eventId)
                         && (serviceId == 0 || offre.ServiceId == serviceId)
                         && (serviceExId == 0 || offre.ServiceExId == serviceExId)
                         && (prixMax == 0 || offre.prixTotal <= prixMax))
                {

                    listeOffreVoyageMulti.Add(offre);

                }

            }
            return listeOffreVoyageMulti;
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

            Itineraire itineraire = new Itineraire() { LieuDepart = LieuDepart, Destination = Destination, Prix = Prix, Transport = Transport, NombreVoyageur = NombreVoyageur, DateDepart = DateDepart, DateRetour = DateArrivee };

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
                itineraire.DateRetour = DateArrivee;
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

        // methodes Membres

        public List<Membre> ObtientTousLesMembres()
        {
            return this._bddContext.Membres.ToList();
        }

        

        public Membre ObtenirMembre(int id)
        {
            return this._bddContext.Membres.Find(id);
        }

        public Membre ObtenirMembre(string idStr)
        {
            int id;
            if (int.TryParse(idStr, out id))
            {
                return this.ObtenirMembre(id);
            }
            return null;
        }

        public int InscriptionMembre(string Nom, string Prenom, string Email,string motDePasse, string Localisation, int Age,Role role)
        { 
            Membre membre = new Membre() { Nom=Nom ,Prenom=Prenom ,Email=Email, MotDePasse=motDePasse,Localisation=Localisation,Age=Age ,User=role };
        _bddContext.Membres.Add(membre);
            _bddContext.SaveChanges();
            return membre.Id;
        }

        public void ModifierMembre(int Id, string Nom, string Prenom, string Email, string Localisation, int Age,Role role)
            {
            Membre membre = _bddContext.Membres.Find(Id);

            if (membre != null)
                {
                membre.Nom = Nom;
                membre.Prenom = Prenom;
                membre.Email = Email;
                membre.Localisation = Localisation;
                membre.Age = Age;
                membre.User = role;
                }
            }
        public void ModifierMembre(Membre membre)
        {


            _bddContext.Membres.Update(membre);
            _bddContext.SaveChanges();
        }
        public void SupprimerMembre(int id) // A tester
        {
            Membre membre = _bddContext.Membres.Find(id);


            if (membre != null)
            {

                _bddContext.Membres.Remove(membre);
            }

        }

        // Methode partenaire
        public List<Partenaire> ObtientTousLesPartenaires()
        {
            return _bddContext.Partenaires.ToList();
        }

        public Partenaire ObtenirPartenaire(int id)
        {
            return this._bddContext.Partenaires.Find(id);
        }

        public Partenaire ObtenirPartenaire(string idStr)
        {
            int id;
            if (int.TryParse(idStr, out id))
            {
                return this.ObtenirPartenaire(id);
            }
            return null;
        }

        public int InscriptionPartenaire(string Nom, string Localisation, string email,string motDePasse, string numSiret, TypeService typeService,Role role)
        {

            Partenaire partenaire = new Partenaire() { Nom = Nom, Localisation = Localisation, email = email, MotDePasse = Dal.EncodeMD5( motDePasse), NumSiret = numSiret, TypeService = typeService, Role = role };

            _bddContext.Partenaires.Add(partenaire);
            _bddContext.SaveChanges();
            return partenaire.Id;
        }

        public void ModifierPartenaire(int Id, string Nom, string motDePasse,string Localisation, string email, string numSiret, TypeService typeService, Role role)
        {
            Partenaire partenaire = _bddContext.Partenaires.Find(Id);

            if (partenaire != null)
            {
                partenaire.Id = Id;
                partenaire.Nom = Nom;
                partenaire.MotDePasse = motDePasse;
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

        // Methodes Reservation

        public List<Reservation> ObtientToutesLesReservations()
        {
            return _bddContext.Reservations.Include(r=>r.Membre)
                .Include(r => r.OffrePayee).ThenInclude(op=>op.Itineraire)
                .Include(r => r.OffrePayee).ThenInclude(op => op.Event)
                .Include(r => r.OffrePayee).ThenInclude(op => op.Service)
                .Include(r => r.OffrePayee).ThenInclude(op => op.ServiceEx)
                .ToList();
        }
        public List<ReservationPerso> ObtientToutesLesReservationsPerso()
        {
            return _bddContext.ReservationPersos.Include(r => r.Membre)
                .Include(r => r.Offre).ThenInclude(op => op.Offre).ThenInclude(op=>op.Event).
                Include(r => r.Offre).ThenInclude(op => op.Offre).
                ThenInclude(op => op.Itineraire)
                .ToList();
        }

        public List<Reservation> ObtientToutesLesReservationsMembre()
        {

            return _bddContext.Reservations.Include(r => r.MembreId).Include(r => r.OffrePayee).ToList();
        }

       
        public int CreerReservation(Membre membre,OffreVoyage offreVoyage)
        {

           Reservation reservation = new Reservation() { MembreId = membre.Id, OffreVoyageId= offreVoyage.Id };

            _bddContext.Reservations.Add(reservation);
            _bddContext.SaveChanges();
            return reservation.Id;
        }

        public int CreerReservationPerso(Membre membre, OffrePerso offreVoyage)
        {

            ReservationPerso reservation = new ReservationPerso() { MembreId = membre.Id, OffreVoyageId = offreVoyage.Id };

            _bddContext.ReservationPersos.Add(reservation);
            _bddContext.SaveChanges();
            return reservation.Id;
        }

        public void ModifierReservation(int Id, Membre membre, OffreVoyage offreVoyage)
        {
            Reservation reservation = _bddContext.Reservations.Find(Id);

            if (reservation!= null)
            {
                reservation.Id = Id;
                reservation.Membre = membre;
                reservation.OffrePayee = offreVoyage;
                _bddContext.SaveChanges();
            }

        }

        public void Modifier(Reservation reservation)
        {


            _bddContext.Reservations.Update(reservation);
            _bddContext.SaveChanges();
        }

        public void SupprimerReservation(int id)
        {
           Reservation reservation = _bddContext.Reservations.Find(id);


            if (reservation != null)
            {

                _bddContext.Reservations.Remove(reservation);


                _bddContext.SaveChanges();
            }
        }

        //Methodes Admin

        public List<Admin> ObtientTousLesAdmins()
        {
            return _bddContext.Admins.ToList();
        }

        public Admin ObtenirAdmin(int id)
        {
            return this._bddContext.Admins.Find(id);
        }

        public Admin ObtenirAdmin(string idStr)
        {
            int id;
            if (int.TryParse(idStr, out id))
            {
                return this.ObtenirAdmin(id);
            }
            return null;
        }


        // Méthodes d'authentification 

        public Membre AuthentifierM(string email, string password)
        {
            string motDePasse = EncodeMD5(password);
            Membre user = this._bddContext.Membres.FirstOrDefault(u => u.Email == email && u.MotDePasse == motDePasse);
            return user;
        }

        public Partenaire AuthentifierP(string email, string password)
        {
            string motDePasse = EncodeMD5(password);
            Partenaire user = this._bddContext.Partenaires.FirstOrDefault(u => u.email == email && u.MotDePasse == motDePasse);
            return user;
        }

        public Admin AuthentifierA(string email, string password)
        {
            string motDePasse = EncodeMD5(password);
            Admin user = this._bddContext.Admins.FirstOrDefault(u=> u.Email == email && u.MotDePasse == motDePasse);
            return user;
        }

        public static string EncodeMD5(string motDePasse)
        {
            string motDePasseSel = "ChoixResto" + motDePasse + "ASP.NET MVC";
            return BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(ASCIIEncoding.Default.GetBytes(motDePasseSel)));
        }

        public void Dispose()
        {
            _bddContext.Dispose();
        }

        List<OffreVoyage> IDal.RechercheMultiCritere(int itineraireId, int eventId, int serviceId, int serviceExId, int Remise, double prixMin, double prixMax)
        {
            throw new NotImplementedException();
        }
    }
}


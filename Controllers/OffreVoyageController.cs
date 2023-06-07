using CodeVoyage.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;


namespace CodeVoyage.Controllers
    {
    public class OffreVoyageController : Controller
        {
        private BddContext _bddContext;

        public OffreVoyageController()
            {
            _bddContext = new BddContext();
            }

        public IActionResult Index()
            {
            return View();
            }
        // Méthodes Créer

        public IActionResult CreerOffreVoyage()
            {
            var itineraires = _bddContext.Itineraires.ToList();
            var evenements = _bddContext.Evenements.ToList();
            var services = _bddContext.Services.ToList();
            ViewBag.ItineraireList = itineraires;
            ViewBag.EvenementList = evenements;
            ViewBag.ServiceList = services;
            return View();
            }


        [HttpPost]
        public IActionResult CreerOffreVoyage(OffreVoyage offreVoyage)
            {


            using (Dal dal = new Dal())
                {
                int id = dal.CreerOffreVoyage(offreVoyage.ItineraireId, offreVoyage.EventId, offreVoyage.ServiceId, offreVoyage.ServiceExId, offreVoyage.Remise, offreVoyage.prixTotal);
                return RedirectToAction("CreerOffreVoyage");
                }

            }

        public ActionResult AjouterOffres(int itineraire, int Event, int service, int serviceextra, int remise, double prixAffiche, double prixTotal)
            {
            using (Dal dal = new Dal())
                {
                dal.CreerOffreVoyage(itineraire, Event, service, serviceextra, remise, prixTotal);
                return RedirectToAction("CreerOffreVoyage");
                }
            }
        //Méthodes Supprimer

        public IActionResult SupprimerOffreVoyage(int id)

            {
            using (Dal dal = new Dal())
                {
                dal.SupprimerOffreVoyage(id);

                return RedirectToAction("AfficherToutesLesOffresVoyages");

                }
            }
        //Méthodes Modifier

        public IActionResult ModifierOffreVoyage(int id)
            {
            var itineraires = _bddContext.Itineraires.ToList();
            var evenements = _bddContext.Evenements.ToList();
            var services = _bddContext.Services.ToList();
            ViewBag.ItineraireList = itineraires;
            ViewBag.EvenementList = evenements;
            ViewBag.ServiceList = services;

            if (id != 0)
                {
                using (Dal dal = new Dal())
                    {
                    OffreVoyage offreVoyage = dal.ObtientToutesLesOffresVoyages().Where(s => s.Id == id).FirstOrDefault();
                    if (offreVoyage == null)
                        {
                        return View("Error");
                        }
                    return View(offreVoyage);
                    }
                }
            return View("Error");

            }

        [HttpPost]
        public IActionResult ModifierOffreVoyage(OffreVoyage offreVoyage)
            {

            if (!ModelState.IsValid)
                return View(offreVoyage);

            if (offreVoyage.Id != 0)
                {
                using (Dal dal = new Dal())
                    {
                    dal.ModifierOffreVoyage(offreVoyage);
                    return RedirectToAction("ModifierOffreVoyage", new { @id = offreVoyage.Id });
                    }
                }
            else
                {
                return View("Error");
                }
            }

        //Méthodes affichage 


        public ActionResult AfficherToutesLesOffresVoyages()

            {
            List<OffreVoyage> offreVoyages;
            using (Dal dal = new Dal())
                {
                offreVoyages = dal.ObtientToutesLesOffresVoyages();

                }


            return View(offreVoyages);

            }


        public IActionResult RechercheOffre(int itineraireId, int eventId, int serviceId, int serviceExId, int prixMax)
            {
            var itineraires = _bddContext.Itineraires.ToList();
            itineraires.Add(new Itineraire() { Id = 0, Destination = "All Destinations" });
            itineraires= itineraires.OrderBy(i => i.Id).ToList();
            var evenements = _bddContext.Evenements.ToList();
            evenements.Add(new Evenement() { Id = 0, Nom = "All Events" });
            evenements =  evenements.OrderBy(i => i.Id).ToList();
            var services = _bddContext.Services.ToList();
            services.Add(new Service { Id = 0, nomService = "All Services" });
            services = services.OrderBy(i => i.Id).ToList();
            ViewBag.ItineraireList = itineraires;
			ViewBag.EvenementList = evenements;
			ViewBag.ServiceList = services;
			ViewBag.prixList = new List<prixMax>() {
				new prixMax { Value = 300 },
				new prixMax { Value = 500 },
				new prixMax { Value = 700 },
				new prixMax { Value = 900 },
				new prixMax { Value = 1100 },
                new prixMax { Value = 1300 },
                new prixMax { Value = 1500 },
                new prixMax { Value = 2000 },




            };


			Dal dal = new Dal();
			List<OffreVoyage> voyages = dal.ObtientToutesLesOffresVoyages();

            if (prixMax != 0)
            {
                voyages = voyages.Where(o => o.prixTotal <= prixMax).ToList();
            }

            if(itineraireId != 0) {
               voyages = voyages.Where(v => v.ItineraireId == itineraireId).ToList();
            }

            if(eventId != 0)
            {
                voyages = voyages.Where(v => v.EventId == eventId).ToList();
            }

            if (serviceId != 0)
            {
                voyages = voyages.Where(v => v.ServiceId == serviceId && v.ServiceExId ==serviceId).ToList();
            }


            return View(voyages);
            }


       }

}




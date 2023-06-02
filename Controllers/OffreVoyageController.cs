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


       /* public IActionResult CreerOffre()
        {

            var itineraires = _bddContext.Itineraires.ToList();
			//var evenements = _bddContext.Evenements.ToList();
			//var service= _bddContext.Services.ToList();
            ViewBag.ItineraireList = itineraires.Select(i => new SelectListItem
			{

				Value = i.Id.ToString(),
				Text = $"{i.Destination}"
			}).ToList();


			return RedirectToAction("CreerOffreVoyage");
        }
	   */
        [HttpPost]
		public IActionResult CreerOffreVoyage(OffreVoyage offreVoyage )
		{


			using (Dal dal = new Dal())
			{
				int id = dal.CreerOffreVoyage(offreVoyage.ItineraireId,offreVoyage.EventId,offreVoyage.ServiceId,offreVoyage.ServiceExId,offreVoyage.Remise, offreVoyage.prixAffiche, offreVoyage.prixTotal);
				return RedirectToAction("CreerOffreVoyage");
			}

		}

        public ActionResult AjouterOffres(int itineraire, int Event, int service, int serviceextra, int remise, double prixAffiche, double prixTotal)
            {
            using (Dal dal = new Dal ())
            {
				dal.CreerOffreVoyage(itineraire, Event, service, serviceextra, remise, prixAffiche, prixTotal);
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


	}


}

	



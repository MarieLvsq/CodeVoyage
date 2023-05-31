﻿using CodeVoyage.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;

namespace CodeVoyage.Controllers
{
	public class OffreVoyageController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
		// Méthodes Créer

		public IActionResult CreerOffreVoyage()
		{
			return View();
		}

		[HttpPost]
		public IActionResult CreerOffreVoyage(Itineraire itineraire , Evenement Event, Service service, Service serviceextra, int remise, double prixAffiche, double prixTotal)
		{


			using (Dal dal = new Dal())
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

		public IActionResult ModifieOffreVoyage(int id)
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

	

